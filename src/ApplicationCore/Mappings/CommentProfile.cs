using ApplicationCore.Commands;
using ApplicationCore.Commands.Comments;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mappings
{
    internal class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentCreateCommand, Comment>().ForMember(x => x.Id, y => y.Ignore());
        }
    }
}
