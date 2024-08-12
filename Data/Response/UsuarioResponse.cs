using Service.Data.Request;

namespace Service.Data.Response;
public class UsuarioResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Correo { get; set; } = null!;
    public string Clave { get; set; } = null!;
    public string Role { get; set; } = null!;

    public UsuarioRequest ToRequest()
    {
        return new UsuarioRequest
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
}