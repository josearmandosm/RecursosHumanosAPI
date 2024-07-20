using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class EmpleadoGetDTO
    {
        public int EmpleadoId { get; set; }
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public required string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? DepartamentoId { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }
        public int? PuestoId { get; set; }
    }
}
