using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class CapacitacionInsertDTO
    {
        [Required]
        [StringLength(100)]
        public required string Titulo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [StringLength(500)]
        public required string Descripcion { get; set; }
    }
}
