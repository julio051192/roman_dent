using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? CitaId { get; set; }

    public int PacienteId { get; set; }

    public string? NumeroComprobante { get; set; }

    public string? TipoComprobante { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? RazonSocial { get; set; }

    public string? Ruc { get; set; }

    public decimal Subtotal { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Igv { get; set; }

    public decimal Total { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public int? RegistradoPor { get; set; }

    public virtual Cita? Cita { get; set; }

    public virtual Paciente Paciente { get; set; } = null!;

    public virtual Usuario? RegistradoPorNavigation { get; set; }
}
