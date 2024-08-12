namespace Service.Data.Request;

public class BecaRequest
{
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


}
