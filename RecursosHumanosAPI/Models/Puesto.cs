using System;
using System.Collections.Generic;

namespace RecursosHumanosAPI.Models;

public partial class Puesto
{
    public int PuestoId { get; set; }

    public string Titulo { get; set; } = null!;

    public decimal Salario { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
