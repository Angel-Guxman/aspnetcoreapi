﻿using ApplicationCore.Commands;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using DevExpress.DataAccess.ObjectBinding;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using DevExpress.


namespace Infraestructure.Services
{
    class EstudiantesService : IEstudiantesService
    {
        private readonly ApplicationDbContext _dbContext;
        public EstudiantesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response<object>> GetEstudiantes()
        {
            object list = new object();
            list = await _dbContext.Estudiantes.ToListAsync();
            return new Response<object>(list);
        }
        public async Task<Response<int>> UpdateEstudiante(EstudianteUpdateCommand command)
        {
            var estudiante = await _dbContext.Estudiantes.FindAsync(command.Id);
            if (estudiante == null)
            {
                return new Response<int>("Estudiante no encontrado.");
            }

            estudiante.Name = command.Name;
            estudiante.Edad = command.Edad;
            estudiante.Correo = command.Correo;

            _dbContext.Estudiantes.Update(estudiante);
            await _dbContext.SaveChangesAsync();

            return new Response<int>(estudiante.Id);
        }
        public async Task<Response<int>> DeleteEstudiante(int id)
        {
            var estudiante = await _dbContext.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return new Response<int>("Estudiante no encontrado.");
            }

            _dbContext.Estudiantes.Remove(estudiante);
            await _dbContext.SaveChangesAsync();

            return new Response<int>(id);
        }

        public async Task<byte[]> GetPDF()
        {
            ObjectDataSource source = new ObjectDataSource();
            var report = new ApplicationCore.pdf.EstudiantePDF();
            var estudiantes = await (from e in _dbContext.Estudiantes
                                     select new EstudianteDTO
                                     {
                                         Id = e.Id,
                                         Name = e.Name,
                                         Edad = e.Edad,
                                         Correo = e.Correo,

                                     }).ToListAsync();

            EstudiantePDFDTO reportePDF = new EstudiantePDFDTO();
            reportePDF.Fecha = DateTime.Now.ToString("dd/mm/yyyy");
            reportePDF.Hora = DateTime.Now.ToString("hh:mm");
            reportePDF.Estudiantes = estudiantes;
            source.DataSource = reportePDF;
            report.DataSource = source;
            using (var memory = new MemoryStream())
            {
                await report.ExportToPdfAsync(memory);
                memory.Position = 0;
                return memory.ToArray();


            }

            // public async Task<byte[]> GetPDF()
            //{
            //  ObjectDataSource source = new ObjectDataSource();
            //}
        }
    }
}
