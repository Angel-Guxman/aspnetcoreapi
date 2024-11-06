using ApplicationCore.Commands;
using ApplicationCore.Commands.Reporte;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mappings
{
    internal class ReporteProfile :Profile
    {
        public ReporteProfile()
        {
            CreateMap<ReporteCreateCommand, Reporte>().ForMember(x => x.Id, y => y.Ignore());
        }
    }
}
