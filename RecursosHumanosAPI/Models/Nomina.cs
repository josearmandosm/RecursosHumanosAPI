using System;
using System.Collections.Generic;

namespace RecursosHumanosAPI.Models;

public partial class Nomina
{
    public int NominaId { get; set; }

    public int? EmpleadoId { get; set; }

    public decimal SalarioBruto { get; set; }

    public decimal Impuestos { get; set; }

    public decimal SalarioNeto { get; set; }

    public DateOnly FechaPago { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
