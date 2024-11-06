using ApplicationCore.Commands;
using ApplicationCore.Commands.Reporte;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    class ReportesService :IReporteService
    {
        private readonly ApplicationDbContext _dbContext;
      
        private readonly IMapper _mapper;
        public ReportesService(ApplicationDbContext dbcontext,IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
            
        }
        public async Task<Response<int>> CreateReportAsync(ReporteDto reporte)
        {
            
                try
                {
                    var p = new ReporteCreateCommand();
                    p.Name = reporte.Name;
                    p.Description = reporte.Description;


                var pe = _mapper.Map<Domain.Entities.Reporte>(p);
                await _dbContext.Reportes.AddAsync(pe);
                var req = await _dbContext.SaveChangesAsync();
                var res = new Response<int>(pe.Id, "Registro creado");


                return res;
                }
                catch (Exception ex)
                {
                    // Manejar otras excepciones
                    
                    throw new Exception("Ha ocurrido un error: " + ex.Message);
                }
            

        }
        public async Task UpdateReportAsync(int id,ReporteDto reporte)
        {

        }
        public async Task DeleteReportAsync(int id)
        {

        }
        public async Task GetOneReportAsync(int id)
        {

        }
        public async Task GetAllReportAsync()
        {

        }

    }
}
