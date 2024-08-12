using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Service.Data.Request;
using Service.Data.Response;


namespace Service.Data.Model;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Correo { get; set; } = null!;
    public string Clave { get; set; } = null!;
    public string Role { get; set; } = null!;
    
    public static Usuario Crear(UsuarioRequest item) => new()
    {
        Nombre = item.Nombre,
        Apellidos = item.Apellidos,
        Matricula = item.Matricula,
        Correo = item.Correo,
        Clave = item.Clave,
        Role = item.Role
    };
    public bool Modificar(UsuarioRequest item)
    {
        var cambio = false;
        if (Nombre != item.Nombre) Nombre = item.Nombre; cambio = true;
        if (Apellidos != item.Apellidos) Apellidos = item.Apellidos; cambio = true;
        if (Matricula != item.Matricula) Matricula = item.Matricula; cambio = true;
        if (Correo != item.Correo) Correo = item.Correo; cambio = true;
        if (Clave != item.Clave) Clave = item.Clave; cambio = true;
        if (Role != item.Role) Role = item.Role; cambio = true;

        return cambio;
    }
    public UsuarioResponse ToResponse() => new()
    {
        Id = Id,
        Nombre = Nombre,
        Apellidos = Apellidos,
        Matricula = Matricula,
        Correo = Correo,
        Clave = Clave,
        Role = Role
    };
}
