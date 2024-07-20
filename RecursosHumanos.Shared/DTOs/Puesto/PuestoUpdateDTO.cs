using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class PuestoUpdateDTO
    {
        [Required]
        [StringLength(100)]
        public required string Titulo { get; set; }

        [StringLength(500)]
        public required string Descripcion { get; set; }

        public int DepartamentoId { get; set; }
        public int PuestoId { get; internal set; }
    }
}
