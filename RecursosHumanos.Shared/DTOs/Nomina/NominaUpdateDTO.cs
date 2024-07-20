using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class NominaUpdateDTO
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salario { get; set; }

        public int EmpleadoId { get; set; }
        public int NominaId { get; internal set; }
    }
}
