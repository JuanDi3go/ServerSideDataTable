using System;
using System.Collections.Generic;

namespace ServerSideDataTable.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public string Oficina { get; set; } = null!;

    public string Salario { get; set; } = null!;

    public int Telefono { get; set; }

    public DateTime FechaIngreso { get; set; }
}
