using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class EspecialidadesOdontologica
{
    public int IdEspecialidad { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? DuracionCitaMinutos { get; set; }

    public decimal? CostoBase { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Odontologo> Odontologos { get; set; } = new List<Odontologo>();
}
