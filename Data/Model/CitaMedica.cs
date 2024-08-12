using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Service.Data.Request;
using Service.Data.Response;


namespace Service.Data.Model;

public class CitaMedica
{
    // Datos personales
    [Key]
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

    public static CitaMedica Crear(CitaMedicaRequest item) => new()
    {
        Nombre = item.Nombre,
        Apellidos = item.Apellidos,
        Matricula = item.Matricula,
        Sexo = item.Sexo,
        Telefono = item.Telefono,
        FechaNacimiento = item.FechaNacimiento,
        Direccion = item.Direccion,
        FechaConsulta = item.FechaConsulta,
        Hora = item.Hora,
        Area = item.Area
    };
    public bool Modificar(CitaMedicaRequest item)
    {
        var cambio = false;
        if (Nombre != item.Nombre) Nombre = item.Nombre; cambio = true;
        if (Apellidos != item.Apellidos) Apellidos = item.Apellidos; cambio = true;
        if (Matricula != item.Matricula) Matricula = item.Matricula; cambio = true;
        if (Sexo != item.Sexo) Sexo = item.Sexo; cambio = true;
        if (Telefono != item.Telefono) Telefono = item.Telefono; cambio = true;
        if (FechaNacimiento != item.FechaNacimiento) FechaNacimiento = item.FechaNacimiento; cambio = true;
        if (Direccion != item.Direccion) Direccion = item.Direccion; cambio = true;
        if (FechaConsulta != item.FechaConsulta) FechaConsulta = item.FechaConsulta; cambio = true;
        if (Hora != item.Hora) Hora = item.Hora; cambio = true;
        if (Area != item.Area) Area = item.Area; cambio = true;

        return cambio;
    }
    public CitaMedicaResponse ToResponse() => new()
    {
        Id = Id,
        Nombre = Nombre,
        Apellidos = Apellidos,
        Matricula = Matricula,
        Sexo = Sexo,
        Telefono = Telefono,
        FechaNacimiento = FechaNacimiento,
        Direccion = Direccion,
        FechaConsulta = FechaConsulta,
        Hora = Hora,
        Area = Area
    };
}
