﻿using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commands.Comments
{
    public class CommentDeleteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
