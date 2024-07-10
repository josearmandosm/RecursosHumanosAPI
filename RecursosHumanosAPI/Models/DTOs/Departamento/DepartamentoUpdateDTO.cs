using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class DepartamentoUpdateDTO
    {
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }
        public int DepartamentoId { get; internal set; }
    }
}
