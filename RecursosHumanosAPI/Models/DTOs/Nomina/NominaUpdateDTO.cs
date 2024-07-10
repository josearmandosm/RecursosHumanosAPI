using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class NominaUpdateDTO
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salario { get; set; }

        public int EmpleadoId { get; set; }
        public int NominaId { get; internal set; }
    }
}
