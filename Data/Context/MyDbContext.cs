using Microsoft.EntityFrameworkCore;
// using TORO.Authentication;
using Service.Data.Model;

namespace Service.Data.Context;
// Cuarto paso inserta el constructor en la clase publica e inserta las tablas de la sigte forma
//public DbSet<Consulta> Consultas { get; set; } y la funcion SaveChangesAsync tanbien inserta las 
//tablas en la interface de la siguiente forma public DbSet<Consulta> Consultas { get; set; }
//Ahora dirijete a la clase Program.cs
#region Interfaz de la clase
public interface IMyDbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tutoria> Tutorias { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Beca> Becas { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
#endregion

public class MyDbContext : DbContext, IMyDbContext
{
    #region Constructor
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration config)
    {
        this.config = config;
    }
    #endregion

    #region Tablas
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tutoria> Tutorias { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<CitaMedica> CitaMedicas { get; set; }
    public DbSet<Beca> Becas { get; set; }
    #endregion

    #region Funciones
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    // internal User? FirstOrDefault(Func<object, bool> value)
    // {
    //     throw new NotImplementedException();
    // }
    #endregion
}