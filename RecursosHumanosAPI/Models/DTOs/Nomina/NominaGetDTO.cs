using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class NominaGetDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salario { get; set; }

        public int EmpleadoId { get; set; }
    }
}
