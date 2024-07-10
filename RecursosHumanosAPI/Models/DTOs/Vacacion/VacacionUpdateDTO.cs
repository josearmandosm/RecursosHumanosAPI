using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class VacacionUpdateDTO
    {
        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public required string Comentarios { get; set; }

        public int EmpleadoId { get; set; }
        public int VacacionId { get; internal set; }
    }
}
