using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class VacacionUpdateDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")] 
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Comentarios { get; set; }

        public int EmpleadoId { get; set; }
        public int VacacionId { get; internal set; }
    }
}
