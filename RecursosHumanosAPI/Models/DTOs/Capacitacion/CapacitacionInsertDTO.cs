using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
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
