using System;
using System.Collections.Generic;

namespace romandent.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string? NumeroHistoriaClinica { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string DocumentoIdentidad { get; set; } = null!;

    public string? TipoDocumento { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public int? Edad { get; set; }

    public string Genero { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? Distrito { get; set; }

    public string? AlergiasMedicamentos { get; set; }

    public string? EnfermedadesSistemicas { get; set; }

    public string? TomaMedicamentos { get; set; }

    public string? TipoSangre { get; set; }

    public string? PresionArterial { get; set; }

    public string? ContactoEmergenciaNombre { get; set; }

    public string? ContactoEmergenciaTelefono { get; set; }

    public string? ContactoEmergenciaParentesco { get; set; }

    public bool? TieneSeguro { get; set; }

    public string? NombreSeguro { get; set; }

    public string? NumeroPoliza { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateOnly? UltimaVisita { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
