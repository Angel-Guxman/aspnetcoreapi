using ApplicationCore.DTOs;
using ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commands.Reporte
{
    public class ReporteDeleteCommand:ReporteDto,IRequest<Response<int>>
    {
    }
}
