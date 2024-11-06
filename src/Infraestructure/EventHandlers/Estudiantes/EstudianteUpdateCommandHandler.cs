using ApplicationCore.Commands;
using ApplicationCore.Wrappers;
using ApplicationCore.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Estudiantes
{
    class EstudianteUpdateCommandHandler : IRequestHandler<EstudianteUpdateCommand, Response<int>>
    {
        private readonly IEstudiantesService _service;

        public EstudianteUpdateCommandHandler(IEstudiantesService service)
        {
            _service = service;
        }

        public async Task<Response<int>> Handle(EstudianteUpdateCommand request, CancellationToken cancellationToken)
        {
            // Llama al servicio para actualizar el estudiante usando los datos del comando
            var result = await _service.UpdateEstudiante(request);

            // Retorna el resultado que contiene el ID del estudiante actualizado o un mensaje de error
            return result;
        }
    }
}
