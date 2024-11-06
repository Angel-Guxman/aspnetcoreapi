using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Estudiantes
{
    public class EstudianteDeleteCommandHandler : IRequestHandler<EstudianteDeleteCommand, Response<int>>
    {
        private readonly IEstudiantesService _service;

        public EstudianteDeleteCommandHandler(IEstudiantesService service)
        {
            _service = service;
        }

        public async Task<Response<int>> Handle(EstudianteDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteEstudiante(request.Id);
        }
    }
}
