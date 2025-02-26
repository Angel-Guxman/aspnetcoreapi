﻿
using ApplicationCore.Interfaces;
using Domain.Entities;
using Finbuckle.MultiTenant;
using Infraestructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class ApplicationDbContext : BaseDbContext
    {
      

        public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUserService currentUser)
            : base(currentTenant, options, currentUser)
        {

        }

        public DbSet<persona> persona {  get; set; }
        public DbSet<logs> logs { get; set; }
        public DbSet<jugador> jugador { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Administrativo> Administrativos { get; set; } // 





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }      
    }
}
