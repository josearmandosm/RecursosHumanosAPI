using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class EvaluacionGetDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Range(0, 5)]
        public int Puntuacion { get; set; }

        public required string Comentarios { get; set; }

        public int EmpleadoId { get; set; }
        public int EvaluacionId { get; set; }
        public string? Descripcion { get; set; }
    }
}
