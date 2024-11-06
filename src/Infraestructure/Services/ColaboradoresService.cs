using ApplicationCore.Commands.Colaboradores;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Domain.Entities;

using Infraestructure.Persistence;
using System.Threading.Tasks;

public class ColaboradoresService : IColaboradorService
{
    private readonly ApplicationDbContext _context;

    public ColaboradoresService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Response<int>> CreateColaborador(ColaboradoresCreateCommand command)
    {
    
        var nuevoColaborador = new Colaborador
        {
            Nombre = command.Nombre,
            Edad = command.Edad,
            BirthDate = command.BirthDate,
            IsProfesor = command.IsProfesor,
            FechaCreacion = command.FechaCreacion
        };

        _context.Colaboradores.Add(nuevoColaborador);
        await _context.SaveChangesAsync();

   
        if (nuevoColaborador.IsProfesor)
        {
            var nuevoProfesor = new Profesor
            {
                FkColaborador = nuevoColaborador.Id
            };
            _context.Set<Profesor>().Add(nuevoProfesor);
        }
        else
        {
            var nuevoAdministrativo = new Administrativo
            {
                FkColaborador = nuevoColaborador.Id
            };
            _context.Set<Administrativo>().Add(nuevoAdministrativo);
        }

    
        await _context.SaveChangesAsync();

    
        return new Response<int>(nuevoColaborador.Id, "Colaborador creado exitosamente.");
    }
}
