using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class DepartamentoInsertDTO
    {
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }
    }
}
