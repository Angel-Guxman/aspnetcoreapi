using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/reporte")]
    [ApiController]
    public class ReporteController :ControllerBase
    {
        private readonly IReporteService _service;
        private readonly IMediator _mediator;
        public ReporteController(IReporteService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Response<int>>> Create([FromBody] ReporteDto request)
        {
            var result = await _service.CreateReportAsync(request);
            //var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
