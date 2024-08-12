namespace Service.Data.Request;

public class TutoriaRequest
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Asignatura { get; set; } = null!;
    public string Tutor { get; set; } = null!;
    public string Dia { get; set; } = null!;
    public DateTime Hora { get; set; } = DateTime.Now;
}