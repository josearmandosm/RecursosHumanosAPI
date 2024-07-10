using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class PuestoInsertDTO
    {
        [Required]
        [StringLength(100)]
        public required string Titulo { get; set; }

        [StringLength(500)]
        public required string Descripcion { get; set; }

        public int DepartamentoId { get; set; }
        public required string Nombre { get; set; }
    }
}
