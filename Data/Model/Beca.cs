using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Service.Data.Request;
using Service.Data.Response;


namespace Service.Data.Model;

public class Beca
{
    [Key]
    public int Id { get; set; }
    
    // Datos Personales
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Matricula { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Sexo { get; set; } = null!;
    public string Nacionalidad { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    
    // Datos Becarios
    public string Carrera { get; set; } = null!;
    public bool Trabaja { get; set; } // True for Si, False for No
    public string? Empleado { get; set; } // Público, Privado, Auto-Empleado, or Ninguno
    public decimal? Sueldo { get; set; } // Nullable in case the person is not working
    public int NumeroHijos { get; set; } = 0;

    public static Beca Crear(BecaRequest item) => new()
    {
        Nombre = item.Nombre,
        Apellidos = item.Apellidos,
        Matricula = item.Matricula,
        FechaNacimiento = item.FechaNacimiento,
        Sexo = item.Sexo,
        Nacionalidad = item.Nacionalidad,
        Telefono = item.Telefono,
        Email = item.Email,
        Direccion = item.Direccion,
        Carrera = item.Carrera,
        Trabaja = item.Trabaja,
        Empleado = item.Empleado,
        Sueldo = item.Sueldo,
        NumeroHijos = item.NumeroHijos
    };
    public bool Modificar(BecaRequest item)
    {
        var cambio = false;
        if (Nombre != item.Nombre) Nombre = item.Nombre; cambio = true;
        if (Apellidos != item.Apellidos) Apellidos = item.Apellidos; cambio = true;
        if (Matricula != item.Matricula) Matricula = item.Matricula; cambio = true;
        if (FechaNacimiento != item.FechaNacimiento) FechaNacimiento = item.FechaNacimiento; cambio = true;
        if (Sexo != item.Sexo) Sexo = item.Sexo; cambio = true;
        if (Nacionalidad != item.Nacionalidad) Nacionalidad = item.Nacionalidad; cambio = true;
        if (Telefono != item.Telefono) Telefono = item.Telefono; cambio = true;
        if (Email != item.Email) Email = item.Email; cambio = true;
        if (Direccion != item.Direccion) Direccion = item.Direccion; cambio = true;
        if (Carrera != item.Carrera) Carrera = item.Carrera; cambio = true;
        if (Trabaja != item.Trabaja) Trabaja = item.Trabaja; cambio = true;
        if (Empleado != item.Empleado) Empleado = item.Empleado; cambio = true;
        if (Sueldo != item.Sueldo) Sueldo = item.Sueldo; cambio = true;
        if (NumeroHijos != item.NumeroHijos) NumeroHijos = item.NumeroHijos; cambio = true;

        return cambio;
    }
    public BecaResponse ToResponse() => new()
    {
        Id = Id,
        Nombre = Nombre,
        Apellidos = Apellidos,
        Matricula = Matricula,
        FechaNacimiento = FechaNacimiento,
        Sexo = Sexo,
        Nacionalidad = Nacionalidad,
        Telefono = Telefono,
        Email = Email,
        Direccion = Direccion,
        Carrera = Carrera,
        Trabaja = Trabaja,
        Empleado = Empleado,
        Sueldo = Sueldo,
        NumeroHijos = NumeroHijos
    };
}
