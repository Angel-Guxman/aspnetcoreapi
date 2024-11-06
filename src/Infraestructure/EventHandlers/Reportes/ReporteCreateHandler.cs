using ApplicationCore.Commands;
using ApplicationCore.Commands.Reporte;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using Infraestructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Reportes
{
    internal class ReporteCreateHandler: IRequestHandler<ReporteCreateCommand,Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
      private readonly IReporteService _reporteService;

        public ReporteCreateHandler(ApplicationDbContext  context, IMapper mapper, IReporteService reporteService )
        {
            _context = context;
            _mapper = mapper;
            _reporteService = reporteService;
            
        }
        public async Task<Response<int>> Handle(ReporteCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var p = new ReporteCreateCommand();
                p.Name = request.Name;
                p.Description = request.Description;
                

                var pe = _mapper.Map<Domain.Entities.Reporte>(p);
                await _context.Reportes.AddAsync(pe);
                var req = await _context.SaveChangesAsync(cancellationToken);
                var res = new Response<int>(pe.Id, "Registro creado");

                

                return res;
            }
            catch (DbUpdateException ex)
            {
              

                // Puedes lanzar la excepción nuevamente o devolver una respuesta de error
                throw new Exception("Error al guardar los cambios en la base de datos.", ex);
            }
            catch (Exception ex)
            {
        

                // Puedes lanzar la excepción nuevamente o devolver una respuesta de error
                throw new Exception("Error Desconocido", ex) ;
            }

        }


    }
}
