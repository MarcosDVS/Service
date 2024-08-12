using Microsoft.EntityFrameworkCore;
using Service.Data.Context;
using Service.Data.Model;
using Service.Data.Request;
using Service.Data.Response;

namespace Service.Data.Services;
// Para crear los servicios es generar un constructor con un mienbro privado de solo lectura
//y crear las funciones del servicio en la clase publica luego crea la interfas
//ahora ve al Program.cs e inserta los servicios de la sigte forma 
//builder.Services.AddScoped<IBecaServices,BecaServices>();
//luego inserta los mismos servicios en el archivo _Import.razor de la sigte forma
//@inject IBecaServices becaServices;

// Una vez ya hallas terminado con los Servicios ya puedes empezar a trabajar la parte visual
//del proyecto en la carpeta Pages.
public class BecaServices : IBecaServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public BecaServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion

    #region Funciones
    public async Task<Result> Crear(BecaRequest request)
    {
        try
        {
            var item = Beca.Crear(request);
            _database.Becas.Add(item);  // Asegúrate de agregar esto
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(BecaRequest request)
    {
        try
        {
            var item = await _database.Becas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el Beca", Success = false };

            if (item.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Eliminar(BecaRequest request)
    {
        try
        {
            var item = await _database.Becas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el usuario", Success = false };

            _database.Becas.Remove(item);
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result<List<BecaResponse>>> Consultar(string filtro)
    {
        try
        {
            var item = await _database.Becas
                .Where(u =>
                    (u.Nombre + " "+ u.Apellidos+" "+ u.Matricula + " "+ u.Sexo+" "+ u.Telefono+" "+ u.Nacionalidad+" "+ u.Carrera+" "+ u.Empleado+" "+ u.Email+" "+ u.Direccion)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<BecaResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = item
            };
        }
        catch (Exception E)
        {
            return new Result<List<BecaResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }
    #endregion
}

public interface IBecaServices
{
    Task<Result<List<BecaResponse>>> Consultar(string filtro);
    Task<Result> Crear(BecaRequest request);
    Task<Result> Eliminar(BecaRequest request);
    Task<Result> Modificar(BecaRequest request);
}