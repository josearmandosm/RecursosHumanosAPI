using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class EmpleadoInsertDTO
    {
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public required string Apellido { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }
        public int? DepartamentoId { get; set; }
        public int? PuestoId { get; set; }
    }
}
