using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace romandent.Models;

public partial class RomanDentContext : DbContext
{
    public RomanDentContext()
    {
    }

    public RomanDentContext(DbContextOptions<RomanDentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Consultorio> Consultorios { get; set; }

    public virtual DbSet<EspecialidadesOdontologica> EspecialidadesOdontologicas { get; set; }

    public virtual DbSet<FormasPago> FormasPagos { get; set; }

    public virtual DbSet<Odontologo> Odontologos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("Server=127.0.0.1,49311;Database=roman_dent;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__citas__6AEC3C090E1D7D7C");

            entity.ToTable("citas");

            entity.HasIndex(e => e.Estado, "idx_estado");

            entity.HasIndex(e => e.FechaHoraInicio, "idx_fecha");

            entity.HasIndex(e => e.OdontologoId, "idx_odontologo");

            entity.HasIndex(e => e.PacienteId, "idx_paciente");

            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.ConsultorioId).HasColumnName("consultorio_id");
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("programada")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaHoraFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora_fin");
            entity.Property(e => e.FechaHoraInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora_inicio");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.MotivoConsulta)
                .HasColumnType("text")
                .HasColumnName("motivo_consulta");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");
            entity.Property(e => e.OdontologoId).HasColumnName("odontologo_id");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.ProximaCita).HasColumnName("proxima_cita");
            entity.Property(e => e.TipoCita)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("primera_vez")
                .HasColumnName("tipo_cita");
            entity.Property(e => e.TratamientoRealizado)
                .HasColumnType("text")
                .HasColumnName("tratamiento_realizado");

            entity.HasOne(d => d.Consultorio).WithMany(p => p.Cita)
                .HasForeignKey(d => d.ConsultorioId)
                .HasConstraintName("FK__citas__consultor__4E88ABD4");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("FK__citas__creado_po__4F7CD00D");

            entity.HasOne(d => d.Odontologo).WithMany(p => p.Cita)
                .HasForeignKey(d => d.OdontologoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__citas__odontolog__4D94879B");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__citas__paciente___4CA06362");
        });

        modelBuilder.Entity<Consultorio>(entity =>
        {
            entity.HasKey(e => e.IdConsultorio).HasName("PK__consulto__500D9D3465599F50");

            entity.ToTable("consultorios");

            entity.HasIndex(e => e.Numero, "UQ__consulto__FC77F2115B289899").IsUnique();

            entity.Property(e => e.IdConsultorio).HasColumnName("id_consultorio");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Equipamiento)
                .HasColumnType("text")
                .HasColumnName("equipamiento");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<EspecialidadesOdontologica>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__especial__C1D13763D3A98C08");

            entity.ToTable("especialidades_odontologicas");

            entity.HasIndex(e => e.Nombre, "UQ__especial__72AFBCC61C4CE363").IsUnique();

            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.CostoBase)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo_base");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.DuracionCitaMinutos)
                .HasDefaultValue(45)
                .HasColumnName("duracion_cita_minutos");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<FormasPago>(entity =>
        {
            entity.HasKey(e => e.IdFormaPago).HasName("PK__formas_p__DA9B39EE7776B052");

            entity.ToTable("formas_pago");

            entity.HasIndex(e => e.Nombre, "UQ__formas_p__72AFBCC65C6EF808").IsUnique();

            entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.ComisionPorcentaje)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("comision_porcentaje");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.RequiereReferencia)
                .HasDefaultValue(false)
                .HasColumnName("requiere_referencia");
        });

        modelBuilder.Entity<Odontologo>(entity =>
        {
            entity.HasKey(e => e.IdOdontologo).HasName("PK__odontolo__FBACF3EBFC41AFA1");

            entity.ToTable("odontologos");

            entity.HasIndex(e => e.DocumentoIdentidad, "UQ__odontolo__1A03B13F5FDF3768").IsUnique();

            entity.HasIndex(e => e.NumeroColegiatura, "UQ__odontolo__D74701062376F6EC").IsUnique();

            entity.HasIndex(e => e.EspecialidadId, "idx_especialidad");

            entity.Property(e => e.IdOdontologo).HasColumnName("id_odontologo");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.ColorAgenda)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("color_agenda");
            entity.Property(e => e.ComisionPorcentaje)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("comision_porcentaje");
            entity.Property(e => e.ConsultorioPrincipalId).HasColumnName("consultorio_principal_id");
            entity.Property(e => e.DocumentoIdentidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documento_identidad");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EspecialidadId).HasColumnName("especialidad_id");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NumeroColegiatura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_colegiatura");
            entity.Property(e => e.TarifaConsulta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("tarifa_consulta");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.ConsultorioPrincipal).WithMany(p => p.Odontologos)
                .HasForeignKey(d => d.ConsultorioPrincipalId)
                .HasConstraintName("FK__odontolog__consu__3E52440B");

            entity.HasOne(d => d.Especialidad).WithMany(p => p.Odontologos)
                .HasForeignKey(d => d.EspecialidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__odontolog__espec__3D5E1FD2");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__paciente__2C2C72BBEB6FF6ED");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.DocumentoIdentidad, "UQ__paciente__1A03B13F460EF57C").IsUnique();

            entity.HasIndex(e => e.NumeroHistoriaClinica, "UQ__paciente__AF36E77390726724").IsUnique();

            entity.HasIndex(e => e.DocumentoIdentidad, "idx_documento");

            entity.HasIndex(e => new { e.Nombres, e.Apellidos }, "idx_nombres");

            entity.HasIndex(e => e.Telefono, "idx_telefono");

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.AlergiasMedicamentos)
                .HasColumnType("text")
                .HasColumnName("alergias_medicamentos");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.ContactoEmergenciaNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contacto_emergencia_nombre");
            entity.Property(e => e.ContactoEmergenciaParentesco)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contacto_emergencia_parentesco");
            entity.Property(e => e.ContactoEmergenciaTelefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contacto_emergencia_telefono");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Distrito)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("distrito");
            entity.Property(e => e.DocumentoIdentidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documento_identidad");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EnfermedadesSistemicas)
                .HasColumnType("text")
                .HasColumnName("enfermedades_sistemicas");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.NombreSeguro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_seguro");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NumeroHistoriaClinica)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_historia_clinica");
            entity.Property(e => e.NumeroPoliza)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_poliza");
            entity.Property(e => e.PresionArterial)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("presion_arterial");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.TieneSeguro)
                .HasDefaultValue(false)
                .HasColumnName("tiene_seguro");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("DNI")
                .HasColumnName("tipo_documento");
            entity.Property(e => e.TipoSangre)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("tipo_sangre");
            entity.Property(e => e.TomaMedicamentos)
                .HasColumnType("text")
                .HasColumnName("toma_medicamentos");
            entity.Property(e => e.UltimaVisita).HasColumnName("ultima_visita");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__pagos__0941B074DAFD3429");

            entity.ToTable("pagos");

            entity.HasIndex(e => e.NumeroComprobante, "UQ__pagos__1850D80D813DF958").IsUnique();

            entity.HasIndex(e => e.Estado, "idx_estado_pago");

            entity.HasIndex(e => e.FechaPago, "idx_fecha_pago");

            entity.HasIndex(e => e.PacienteId, "idx_paciente_pago");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.CitaId).HasColumnName("cita_id");
            entity.Property(e => e.Descuento)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.Igv)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("igv");
            entity.Property(e => e.NumeroComprobante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_comprobante");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.RegistradoPor).HasColumnName("registrado_por");
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.TipoComprobante)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("boleta")
                .HasColumnName("tipo_comprobante");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Cita).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.CitaId)
                .HasConstraintName("FK__pagos__cita_id__68487DD7");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pagos__paciente___693CA210");

            entity.HasOne(d => d.RegistradoPorNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.RegistradoPor)
                .HasConstraintName("FK__pagos__registrad__6A30C649");
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTratamiento).HasName("PK__tratamie__C8825F4C4710718D");

            entity.ToTable("tratamientos");

            entity.HasIndex(e => e.Codigo, "UQ__tratamie__40F9A206B6614033").IsUnique();

            entity.HasIndex(e => e.Categoria, "idx_categoria");

            entity.HasIndex(e => e.Codigo, "idx_codigo");

            entity.Property(e => e.IdTratamiento).HasColumnName("id_tratamiento");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Categoria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.DuracionMinutos)
                .HasDefaultValue(45)
                .HasColumnName("duracion_minutos");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.RequiereAnestesia)
                .HasDefaultValue(false)
                .HasColumnName("requiere_anestesia");
            entity.Property(e => e.SesionesRequeridas)
                .HasDefaultValue(1)
                .HasColumnName("sesiones_requeridas");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD573868FF");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Username, "UQ__usuarios__F3DBC572E12B548A").IsUnique();

            entity.HasIndex(e => e.Username, "idx_username");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.OdontologoId).HasColumnName("odontologo_id");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.UltimoAcceso)
                .HasColumnType("datetime")
                .HasColumnName("ultimo_acceso");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Odontologo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.OdontologoId)
                .HasConstraintName("FK__usuarios__odonto__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
