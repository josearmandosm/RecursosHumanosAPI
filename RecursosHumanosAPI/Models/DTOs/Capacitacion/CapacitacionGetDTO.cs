﻿using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosAPI.DTOs
{
    public class CapacitacionGetDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Titulo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [StringLength(500)]
        public required string Descripcion { get; set; }
        public object? CapacitacionId { get; internal set; }
    }
}
