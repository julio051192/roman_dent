using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class Odontologo
{
    public int IdOdontologo { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int EspecialidadId { get; set; }

    public string NumeroColegiatura { get; set; } = null!;

    public string? DocumentoIdentidad { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public int? ConsultorioPrincipalId { get; set; }

    public string? ColorAgenda { get; set; }

    public decimal? TarifaConsulta { get; set; }

    public decimal? ComisionPorcentaje { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Consultorio? ConsultorioPrincipal { get; set; }

    public virtual EspecialidadesOdontologica Especialidad { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
