using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public int? OdontologoId { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public bool? Activo { get; set; }

    public DateTime? UltimoAcceso { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Odontologo? Odontologo { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
