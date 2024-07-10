using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class BeneficioUpdateDTO
    {
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [StringLength(500)]
        public required string Descripcion { get; set; }
    }
}
