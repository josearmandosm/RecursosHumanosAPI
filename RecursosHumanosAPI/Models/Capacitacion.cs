using System;
using System.Collections.Generic;

namespace RecursosHumanosAPI.Models;

public partial class Capacitacion
{
    public int CapacitacionId { get; set; }

    public int? EmpleadoId { get; set; }

    public string NombreCurso { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
