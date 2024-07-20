﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Shared
{
    public class BeneficioInsertDTO
    {
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [StringLength(500)]
        public required string Descripcion { get; set; }
    }
}
