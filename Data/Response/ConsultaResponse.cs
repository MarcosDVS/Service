using Service.Data.Request;

namespace Service.Data.Response;

public class ConsultaResponse
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


    public ConsultaRequest ToRequest()
    {
        return new ConsultaRequest
        {
            Id=Id,
            Nombre=Nombre,
            Apellidos=Apellidos,
            Matricula=Matricula,
            Sexo=Sexo,
            Telefono=Telefono,
            Edad=Edad,
            Fecha=Fecha,
            Hora=Hora
        };
    }
}