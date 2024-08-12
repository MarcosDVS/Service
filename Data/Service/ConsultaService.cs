using Microsoft.EntityFrameworkCore;
using Service.Data.Context;
using Service.Data.Model;
using Service.Data.Request;
using Service.Data.Response;

namespace Service.Data.Services;
// Para crear los servicios es generar un constructor con un mienbro privado de solo lectura
//y crear las funciones del servicio en la clase publica luego crea la interfas
//ahora ve al Program.cs e inserta los servicios de la sigte forma 
//builder.Services.AddScoped<IConsultaServices,ConsultaServices>();
//luego inserta los mismos servicios en el archivo _Import.razor de la sigte forma
//@inject IConsultaServices consultaServices;

// Una vez ya hallas terminado con los Servicios ya puedes empezar a trabajar la parte visual
//del proyecto en la carpeta Pages.
public class ConsultaServices : IConsultaServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public ConsultaServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion

    #region Funciones
    public async Task<Result> Crear(ConsultaRequest request)
    {
        try
        {
            var item = Consulta.Crear(request);
            _database.Consultas.Add(item);  // Asegúrate de agregar esto
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(ConsultaRequest request)
    {
        try
        {
            var item = await _database.Consultas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el Consulta", Success = false };

            if (item.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Eliminar(ConsultaRequest request)
    {
        try
        {
            var item = await _database.Consultas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el usuario", Success = false };

            _database.Consultas.Remove(item);
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result<List<ConsultaResponse>>> Consultar(string filtro)
    {
        try
        {
            var item = await _database.Consultas
                .Where(u =>
                    (u.Nombre + " "+ u.Apellidos+" "+ u.Matricula + " "+ u.Sexo+" "+ u.Telefono+" "+ u.Edad+" "+ u.Fecha)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<ConsultaResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = item
            };
        }
        catch (Exception E)
        {
            return new Result<List<ConsultaResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }
    #endregion
}

public interface IConsultaServices
{
    Task<Result<List<ConsultaResponse>>> Consultar(string filtro);
    Task<Result> Crear(ConsultaRequest request);
    Task<Result> Eliminar(ConsultaRequest request);
    Task<Result> Modificar(ConsultaRequest request);
}