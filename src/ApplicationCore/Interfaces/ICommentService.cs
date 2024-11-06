using ApplicationCore.Commands.Comments;
using ApplicationCore.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICommentService
    {
        Task<Response<object>> GetComments();
        Task<Response<int>> UpdateComment(CommentUpdateCommand commentUpdateCommand);
        //Task<Response<int>> DeleteComment(int id);
      
    }
}
