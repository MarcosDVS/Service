using Microsoft.EntityFrameworkCore;
using Service.Data.Context;
using Service.Data.Model;
using Service.Data.Request;
using Service.Data.Response;

namespace Service.Data.Services;
// Para crear los servicios es generar un constructor con un mienbro privado de solo lectura
//y crear las funciones del servicio en la clase publica luego crea la interfas
//ahora ve al Program.cs e inserta los servicios de la sigte forma 
//builder.Services.AddScoped<ITutoriaServices,TutoriaServices>();
//luego inserta los mismos servicios en el archivo _Import.razor de la sigte forma
//@inject ITutoriaServices TutoriaServices;

// Una vez ya hallas terminado con los Servicios ya puedes empezar a trabajar la parte visual
//del proyecto en la carpeta Pages.
public class TutoriaServices : ITutoriaServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public TutoriaServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion
    #region Funciones
    public async Task<Result> Crear(TutoriaRequest request)
    {
        try
        {
            var item = Tutoria.Crear(request);
            _database.Tutorias.Add(item);  // Asegúrate de agregar esto
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(TutoriaRequest request)
    {
        try
        {
            var item = await _database.Tutorias
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el Tutoria", Success = false };

            if (item.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Eliminar(TutoriaRequest request)
    {
        try
        {
            var item = await _database.Tutorias
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Message = "No se encontro el usuario", Success = false };

            _database.Tutorias.Remove(item);
            await _database.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {

            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result<List<TutoriaResponse>>> Consultar(string filtro)
    {
        try
        {
            var item = await _database.Tutorias
                .Where(u =>
                    (u.Nombre + " "+ u.Apellidos+" "+ u.Matricula + " "+ u.Asignatura+" "+ u.Tutor+" "+ u.Dia+" "+ u.Hora)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<TutoriaResponse>>()
            {
                Message = "Ok",
                Success = true,
                Data = item
            };
        }
        catch (Exception E)
        {
            return new Result<List<TutoriaResponse>>
            {
                Message = E.Message,
                Success = false
            };
        }
    }
    #endregion
}

public interface ITutoriaServices
{
    Task<Result<List<TutoriaResponse>>> Consultar(string filtro);
    Task<Result> Crear(TutoriaRequest request);
    Task<Result> Eliminar(TutoriaRequest request);
    Task<Result> Modificar(TutoriaRequest request);
}