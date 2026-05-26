using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class Tratamiento
{
    public int IdTratamiento { get; set; }

    public string? Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Categoria { get; set; } = null!;

    public decimal Costo { get; set; }

    public int? DuracionMinutos { get; set; }

    public int? SesionesRequeridas { get; set; }

    public bool? RequiereAnestesia { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
