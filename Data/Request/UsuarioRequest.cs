
namespace Service.Data.Request;
public class UsuarioRequest
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Correo { get; set; } = null!;
    public string Clave { get; set; } = null!;
    public string Role { get; set; } = null!;
}