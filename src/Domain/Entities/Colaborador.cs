﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Colaboradores")]
    public class Colaborador
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public DateTime BirthDate { get; set; } = new DateTime();
        public bool IsProfesor { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
