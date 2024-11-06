using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Commands.Colaboradores
{
    public class ColaboradoresCreateCommand
    {
        public int ?Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public DateTime BirthDate { get; set; } = new DateTime();
        public bool IsProfesor { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
