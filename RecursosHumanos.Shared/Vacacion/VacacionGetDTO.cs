using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class VacacionGetDTO
    {
        public int VacacionId { get; set; }
        public int Id { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public required string Comentarios { get; set; }

        public int EmpleadoId { get; set; }
    }
}
