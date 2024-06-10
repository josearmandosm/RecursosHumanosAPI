﻿using System;
using System.Collections.Generic;

namespace RecursosHumanosAPI.Models;

public partial class Departamento
{
    public int DepartamentoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
