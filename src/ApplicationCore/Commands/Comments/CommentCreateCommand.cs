using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commands.Comments
{
    public class CommentCreateCommand : IRequest<Response<int>>
    {
        public int ?Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
