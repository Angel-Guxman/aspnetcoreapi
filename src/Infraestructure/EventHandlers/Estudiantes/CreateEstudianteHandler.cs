using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Estudiantes
{
    public class CreateEstudianteHandler: IRequestHandler<EstudianteCreateCommand,Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEstudiantesService _service;
        public CreateEstudianteHandler(ApplicationDbContext context, IMapper mapper, IEstudiantesService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;

        }

        public async Task<Response<int>> Handle(EstudianteCreateCommand command,CancellationToken cancellationToken)
        {
         
            var estudiante = _mapper.Map<Domain.Entities.Estudiantes>(command);

          
            await _context.AddAsync(estudiante, cancellationToken);

       
            var request = await _context.SaveChangesAsync(cancellationToken);

           
            return new Response<int>(estudiante.Id, "Registro exitoso modificado");


        }


    }
}
