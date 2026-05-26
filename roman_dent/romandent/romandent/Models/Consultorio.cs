using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class Consultorio
{
    public int IdConsultorio { get; set; }

    public string Numero { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public string? Equipamiento { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Odontologo> Odontologos { get; set; } = new List<Odontologo>();
}
