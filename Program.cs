using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Service.Authentication;
using Service.Data;
using Service.Data.Context;
using Service.Data.Services;
using Test.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

#region Configuracion de la base de datos SQLserver
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
#endregion

#region Servicios
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<ITutoriaServices, TutoriaServices>();
builder.Services.AddScoped<IConsultaServices,ConsultaServices>();
builder.Services.AddScoped<IBecaServices,BecaServices>();
builder.Services.AddScoped<ICitaMedicaServices,CitaMedicaServices>();
#endregion

#region Authentication
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddSingleton<UserAccountService>();
builder.Services.AddScoped<IUserAccountService,UserAccountService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var serviceScope =  app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider
        .GetRequiredService<MyDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
