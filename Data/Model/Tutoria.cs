using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Service.Data.Request;
using Service.Data.Response;


namespace Service.Data.Model;

public class Tutoria
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public string Asignatura { get; set; } = null!;
    public string Tutor { get; set; } = null!;
    public string Dia { get; set; } = null!;
    public DateTime Hora { get; set; }
    
    public static Tutoria Crear(TutoriaRequest item) => new()
    {
        Nombre = item.Nombre,
        Apellidos = item.Apellidos,
        Matricula = item.Matricula,
        Asignatura = item.Asignatura,
        Tutor = item.Tutor,
        Dia = item.Dia,
        Hora = item.Hora
    };
    public bool Modificar(TutoriaRequest item)
    {
        var cambio = false;
        if (Nombre != item.Nombre) Nombre = item.Nombre; cambio = true;
        if (Apellidos != item.Apellidos) Apellidos = item.Apellidos; cambio = true;
        if (Matricula != item.Matricula) Matricula = item.Matricula; cambio = true;
        if (Asignatura != item.Asignatura) Asignatura = item.Asignatura; cambio = true;
        if (Tutor != item.Tutor) Tutor = item.Tutor; cambio = true;
        if (Dia != item.Dia) Dia = item.Dia; cambio = true;
        if (Hora != item.Hora) Hora = item.Hora; cambio = true;

        return cambio;
    }
    public TutoriaResponse ToResponse() => new()
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
