﻿namespace RecursosHumanosAPI.Models.DTOs.Empleado
{
    public class EmpleadoUpdateDTO
    {
        public int EmpleadoId { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? DepartamentoId { get; set; }
        public int? PuestoId { get; set; }
    }
}
