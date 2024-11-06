using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using MediatR;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
//using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Host.Controllers
{
        [Route("api/estudiantes")]
        [ApiController]
    public class EstudiantesController:ControllerBase
    {
        private readonly IEstudiantesService _service;
        private readonly IMediator _mediator;

        public EstudiantesController(IEstudiantesService service,IMediator mediator)
        {
            _service = service;
            _mediator = mediator;


        }
        [HttpGet("get")]
        public async Task<IActionResult> GetEstudiantes()
        {
            var result = await _service.GetEstudiantes();
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Response<int>>> CreateEstudiante(EstudianteCreateCommand command)
        {
            var result=await _mediator.Send(command);
            return Ok(result);

        }
        [HttpPut("update")]
        public async Task<ActionResult<Response<int>>> UpdateEstudiante(EstudianteUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Response<int>>> DeleteEstudiante(int id)
        {
            var result = await _mediator.Send(new EstudianteDeleteCommand { Id = id });
            return Ok(result);
        }

    }
}
