
using ApplicationCore.Commands;
using ApplicationCore.Commands.Comments;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController :ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IMediator _mediator;
        public CommentController(ICommentService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }


        [HttpGet("get")]
        public async Task<IActionResult> GetComments()
        {
            var result = await _service.GetComments();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Response<int>>> UpdateComment(CommentUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
