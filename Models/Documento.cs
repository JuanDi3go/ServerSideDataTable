using System;
using System.Collections.Generic;

namespace ServerSideDataTable.Models;

public partial class Documento
{
    public int IdDocumento { get; set; }

    public string? Descripcion { get; set; }

    public string? Ruta { get; set; }
}
