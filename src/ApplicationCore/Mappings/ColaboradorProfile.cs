using ApplicationCore.Commands.Colaboradores;
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
    internal class ColaboradorProfile : Profile
    {
        public ColaboradorProfile()
        {
            CreateMap<ColaboradoresCreateCommand, Colaborador>().ForMember(x => x.Id, y => y.Ignore());
        }

    }
}
