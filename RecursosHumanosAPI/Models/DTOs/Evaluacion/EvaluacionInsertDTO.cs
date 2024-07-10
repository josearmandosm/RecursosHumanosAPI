using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class EvaluacionInsertDTO
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Range(0, 5)]
        public int Puntuacion { get; set; }

        public required string Comentarios { get; set; }

        public int EmpleadoId { get; set; }
        public string? Descripcion { get; set; }
    }
}
