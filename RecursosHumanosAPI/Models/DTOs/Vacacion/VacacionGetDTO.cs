using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
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
