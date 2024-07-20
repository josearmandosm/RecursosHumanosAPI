using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class DepartamentoGetDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }
        public object? DepartamentoId { get; internal set; }
    }
}
