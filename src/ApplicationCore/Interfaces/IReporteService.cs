using ApplicationCore.DTOs;
using ApplicationCore.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IReporteService
    {
        Task <Response<int>> CreateReportAsync(ReporteDto reporteDto);
        //Task<Response<object>> UpdateReportAsync(int id ,ReporteDto reporteDto  );
        //Task DeleteReportAsync(int id);
        //Task<ReporteDto> GetOneReportAsync(int id);
        //Task<IEnumerable<ReporteDto>> GetAllReportAsync();


    }
}
