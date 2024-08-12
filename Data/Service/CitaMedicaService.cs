using Microsoft.EntityFrameworkCore;
using Service.Data.Context;
using Service.Data.Model;
using Service.Data.Request;
using Service.Data.Response;

namespace Service.Data.Services;
// Para crear los servicios es generar un constructor con un mienbro privado de solo lectura
//y crear las funciones del servicio en la clase publica luego crea la interfas
//ahora ve al Program.cs e inserta los servicios de la sigte forma 
//builder.Services.AddScoped<ICitaMedicaServices,CitaMedicaServices>();
//luego inserta los mismos servicios en el archivo _Import.razor de la sigte forma
//@inject ICitaMedicaServices citaMedicaServices;

// Una vez ya hallas terminado con los Servicios ya puedes empezar a trabajar la parte visual
//del proyecto en la carpeta Pages.
public class CitaMedicaServices : ICitaMedicaServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public CitaMedicaServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion

    #region Funciones
    public async Task<Result> Crear(CitaMedicaRequest request)
    {
        try
        {
            var item = CitaMedica.Crear(request);
            _database.CitaMedicas.Add(item);  // Asegúrate de agregar esto
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(CitaMedicaRequest request)
    {
        try
        {
            var item = await _database.CitaMedicas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el CitaMedica", Success = false };

            if (item.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Eliminar(CitaMedicaRequest request)
    {
        try
        {
            var item = await _database.CitaMedicas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el usuario", Success = false };

            _database.CitaMedicas.Remove(item);
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result<List<CitaMedicaResponse>>> Consultar(string filtro)
    {
        try
        {
            var item = await _database.CitaMedicas
                .Where(u =>
                    (u.Nombre + " "+ u.Apellidos+" "+ u.Matricula + " "+ u.Sexo+" "+ u.Telefono+" "+ u.FechaNacimiento+" "+ u.FechaConsulta+" "+ u.Area+" "+ u.Hora+" "+ u.Direccion)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<CitaMedicaResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = item
            };
        }
        catch (Exception E)
        {
            return new Result<List<CitaMedicaResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }
    #endregion
}

public interface ICitaMedicaServices
{
    Task<Result<List<CitaMedicaResponse>>> Consultar(string filtro);
    Task<Result> Crear(CitaMedicaRequest request);
    Task<Result> Eliminar(CitaMedicaRequest request);
    Task<Result> Modificar(CitaMedicaRequest request);
}