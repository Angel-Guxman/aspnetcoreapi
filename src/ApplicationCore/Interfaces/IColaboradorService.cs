﻿using ApplicationCore.Commands.Colaboradores;
using ApplicationCore.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
   public interface IColaboradorService
    {
        Task<Response<int>> CreateColaborador(ColaboradoresCreateCommand command);




    }
}
