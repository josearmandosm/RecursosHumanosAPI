using System;
using System.Collections.Generic;

namespace RecursosHumanosAPI.Models;

public partial class Vacacion
{
    public int VacacionId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public bool Aprobado { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
