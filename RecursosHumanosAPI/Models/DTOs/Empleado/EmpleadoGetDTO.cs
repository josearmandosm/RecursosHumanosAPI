using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class EmpleadoGetDTO
    {
        public int EmpleadoId { get; set; }
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public required string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? DepartamentoId { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }
        public int? PuestoId { get; set; }
    }
}
