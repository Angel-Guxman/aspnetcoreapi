using ApplicationCore.Commands.Comments;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class CommentService :ICommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Response<object>> GetComments()
        {
            object list = new object();
            list = await _context.Comments.ToListAsync();
            return new Response<object>(list,"Mira la lista probando");
        }

        public async Task<Response<int>> UpdateComment(CommentUpdateCommand commentUpdateCommand)
        {
            var comment = await _context.Comments.FindAsync(commentUpdateCommand.Id);
            if (comment == null)
            {
                return new Response<int>("Comentario no encontrado.");
            }

            comment.Name = commentUpdateCommand.Name;
            comment.Description=commentUpdateCommand.Description;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return new Response<int>(comment.Id,"Comentario actualizado con exito");
        }

    }
}
