using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class FormasPago
{
    public int IdFormaPago { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? RequiereReferencia { get; set; }

    public decimal? ComisionPorcentaje { get; set; }

    public bool? Activo { get; set; }
}
