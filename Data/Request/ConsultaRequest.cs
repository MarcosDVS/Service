namespace Service.Data.Request;

public class ConsultaRequest
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Sexo { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public int Edad { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public DateTime Hora { get; set; }
}