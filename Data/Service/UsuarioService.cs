using Microsoft.EntityFrameworkCore;
using Service.Data.Context;
using Service.Data.Model;
using Service.Data.Request;
using Service.Data.Response;

namespace Service.Data.Services;
// Para crear los servicios es generar un constructor con un mienbro privado de solo lectura
//y crear las funciones del servicio en la clase publica luego crea la interfas
//ahora ve al Program.cs e inserta los servicios de la sigte forma 
//builder.Services.AddScoped<IUsuarioServices,UsuarioServices>();
//luego inserta los mismos servicios en el archivo _Import.razor de la sigte forma
//@inject IUsuarioServices usuarioServices;

// Una vez ya hallas terminado con los Servicios ya puedes empezar a trabajar la parte visual
//del proyecto en la carpeta Pages.
public class UsuarioServices : IUsuarioServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public UsuarioServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion

    #region Funciones
    public async Task<Result> Crear(UsuarioRequest request)
    {
        try
        {
            var item = Usuario.Crear(request);
            _database.Usuarios.Add(item);  // Asegúrate de agregar esto
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(UsuarioRequest request)
    {
        try
        {
            var item = await _database.Usuarios
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el Usuario", Success = false };

            if (item.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Eliminar(UsuarioRequest request)
    {
        try
        {
            var item = await _database.Usuarios
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el usuario", Success = false };

            _database.Usuarios.Remove(item);
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result<List<UsuarioResponse>>> Consultar(string filtro)
    {
        try
        {
            var item = await _database.Usuarios
                .Where(u =>
                    (u.Nombre + " "+ u.Apellidos+" "+ u.Matricula + " "+ u.Correo+" "+ u.Role)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<UsuarioResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = item
            };
        }
        catch (Exception E)
        {
            return new Result<List<UsuarioResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }
    
    public async Task CrearUsuariosAdmin()
    {
        // Lista de usuarios a crear
        var usuarios = new List<Usuario>
        {
            new Usuario
            {
                Nombre = "Natalia",
                Apellidos = "Guzman Serrano",
                Matricula = "2021-1119",
                Correo = "2021-1119",
                Clave = "1234", // Recuerda realizar un hash de la contraseña en un entorno de producción
                Role = "Admin"
            },
            new Usuario
            {
                Nombre = "Jesmerlin Paola",
                Apellidos = "Santana Concepción",
                Matricula = "2022-0161",
                Correo = "2022-0161",
                Clave = "abcd", // Recuerda realizar un hash de la contraseña en un entorno de producción
                Role = "Student"
            },
            new Usuario
            {
                Nombre = "Luis Mario",
                Apellidos = "Batista",
                Matricula = "2021-0007",
                Correo = "2021-0007",
                Clave = "5678", // Recuerda realizar un hash de la contraseña en un entorno de producción
                Role = "Student"
            },
            new Usuario
            {
                Nombre = "Marcos",
                Apellidos = "De Vargas",
                Matricula = "2020-0288",
                Correo = "2020-0288",
                Clave = "admin123", // Recuerda realizar un hash de la contraseña en un entorno de producción
                Role = "Student"
            }
        };

        // Verifica si alguno de los usuarios ya existe
        foreach (var usuario in usuarios)
        {
            var existingUser = await _database.Usuarios.FirstOrDefaultAsync(u => u.Correo == usuario.Correo);
            if (existingUser == null)
            {
                _database.Usuarios.Add(usuario);
            }
        }

        await _database.SaveChangesAsync();
    }
    #endregion
}

public interface IUsuarioServices
{
    Task<Result<List<UsuarioResponse>>> Consultar(string filtro);
    Task<Result> Crear(UsuarioRequest request);
    Task<Result> Eliminar(UsuarioRequest request);
    Task<Result> Modificar(UsuarioRequest request);
    Task CrearUsuariosAdmin();
}