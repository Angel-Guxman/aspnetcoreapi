﻿using ApplicationCore.Commands;
using ApplicationCore.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IEstudiantesService
    {
        Task<Response<object>> GetEstudiantes();
        Task<Response<int>> UpdateEstudiante(EstudianteUpdateCommand command);
        Task<Response<int>> DeleteEstudiante(int id);
        Task<byte[]> GetPDF();
    }
}
