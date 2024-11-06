using ApplicationCore.Commands;
using ApplicationCore.Commands.Comments;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Comments
{
    public class CommentCreateHandler : IRequestHandler<CommentCreateCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        public CommentCreateHandler(ApplicationDbContext applicationDbContext,IMapper mapper, ICommentService commentService)
        {
            _context = applicationDbContext;
            _mapper = mapper;
            _commentService = commentService;
            
        }
        public async Task<Response<int>> Handle(CommentCreateCommand commentCreateCommand,CancellationToken cancellationToken)
        {
            try
            {

                var comment = _mapper.Map<Domain.Entities.Comment>(commentCreateCommand);
                await _context.AddAsync(comment,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return new Response<int>(comment.Id, "Comentario guardado correctamente");
            }
            catch (Exception ex) {
                throw new Exception("ocurrio un error al guardar el comentario en la BD: " + ex.Message);
            }




        }
    }
}
