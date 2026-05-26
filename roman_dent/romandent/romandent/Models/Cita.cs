using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class Cita
{
    public int IdCita { get; set; }

    public int PacienteId { get; set; }

    public int OdontologoId { get; set; }

    public int? ConsultorioId { get; set; }

    public DateTime FechaHoraInicio { get; set; }

    public DateTime FechaHoraFin { get; set; }

    public string? Estado { get; set; }

    public string? MotivoConsulta { get; set; }

    public string? TipoCita { get; set; }

    public string? Observaciones { get; set; }

    public string? TratamientoRealizado { get; set; }

    public DateOnly? ProximaCita { get; set; }

    public int? CreadoPor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Consultorio? Consultorio { get; set; }

    public virtual Usuario? CreadoPorNavigation { get; set; }

    public virtual Odontologo Odontologo { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
