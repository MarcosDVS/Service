using Service.Data.Request;

namespace Service.Data.Response;
public class TutoriaResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Asignatura { get; set; } = null!;
    public string Tutor { get; set; } = null!;
    public string Dia { get; set; } = null!;
    public DateTime Hora { get; set; }

    public TutoriaRequest ToRequest()
    {
        return new TutoriaRequest
        {
            Id = Id,
            Nombre = Nombre,
            Apellidos = Apellidos,
            Matricula = Matricula,
            Asignatura = Asignatura,
            Tutor = Tutor,
            Dia = Dia,
            Hora = Hora
        };
    }
}