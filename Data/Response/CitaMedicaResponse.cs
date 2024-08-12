using Service.Data.Request;

namespace Service.Data.Response;

public class CitaMedicaResponse
{
    // Datos personales
    public int Id { get; set; } // Primary Key
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Sexo { get; set; } = null!;
    public string? Telefono { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string? Direccion { get; set; }

    // Datos de la cita
    public DateTime FechaConsulta { get; set; }
    public DateTime Hora { get; set; }
    public string Area { get; set; } = null!;

    public CitaMedicaRequest ToRequest()
    {
        return new CitaMedicaRequest
        {
            Id=Id,
            Nombre=Nombre,
            Apellidos=Apellidos,
            Matricula=Matricula,
            Sexo=Sexo,
            Telefono=Telefono,
            FechaNacimiento=FechaNacimiento,
            Direccion=Direccion,
            FechaConsulta=FechaConsulta,
            Hora=Hora,
            Area=Area
        };
    }
}
