using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Service.Data.Request;
using Service.Data.Response;


namespace Service.Data.Model;

public class Consulta
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Sexo { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public int Edad { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public DateTime Hora { get; set; }

    
    public static Consulta Crear(ConsultaRequest item) => new()
    {
        Nombre = item.Nombre,
        Apellidos = item.Apellidos,
        Matricula = item.Matricula,
        Sexo = item.Sexo,
        Telefono = item.Telefono,
        Edad = item.Edad,
        Fecha = item.Fecha,
        Hora = item.Hora
    };
    public bool Modificar(ConsultaRequest item)
    {
        var cambio = false;
        if (Nombre != item.Nombre) Nombre = item.Nombre; cambio = true;
        if (Apellidos != item.Apellidos) Apellidos = item.Apellidos; cambio = true;
        if (Matricula != item.Matricula) Matricula = item.Matricula; cambio = true;
        if (Sexo != item.Sexo) Sexo = item.Sexo; cambio = true;
        if (Telefono != item.Telefono) Telefono = item.Telefono; cambio = true;
        if (Edad != item.Edad) Edad = item.Edad; cambio = true;
        if (Fecha != item.Fecha) Fecha = item.Fecha; cambio = true;
        if (Hora != item.Hora) Hora = item.Hora; cambio = true;

        return cambio;
    }
    public ConsultaResponse ToResponse() => new()
    {
        Id = Id,
        Nombre = Nombre,
        Apellidos = Apellidos,
        Matricula = Matricula,
        Sexo = Sexo,
        Telefono = Telefono,
        Edad = Edad,
        Fecha = Fecha,
        Hora = Hora
    };
}
