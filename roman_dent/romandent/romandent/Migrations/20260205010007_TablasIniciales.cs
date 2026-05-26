using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace romandent.Migrations
{
    /// <inheritdoc />
    public partial class TablasIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consultorios",
                columns: table => new
                {
                    id_consultorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ubicacion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    equipamiento = table.Column<string>(type: "text", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__consulto__500D9D3465599F50", x => x.id_consultorio);
                });

            migrationBuilder.CreateTable(
                name: "especialidades_odontologicas",
                columns: table => new
                {
                    id_especialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    duracion_cita_minutos = table.Column<int>(type: "int", nullable: true, defaultValue: 45),
                    costo_base = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__especial__C1D13763D3A98C08", x => x.id_especialidad);
                });

            migrationBuilder.CreateTable(
                name: "formas_pago",
                columns: table => new
                {
                    id_forma_pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    requiere_referencia = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    comision_porcentaje = table.Column<decimal>(type: "decimal(5,2)", nullable: true, defaultValue: 0m),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__formas_p__DA9B39EE7776B052", x => x.id_forma_pago);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_historia_clinica = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    nombres = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    documento_identidad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    tipo_documento = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "DNI"),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: true),
                    genero = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    direccion = table.Column<string>(type: "text", nullable: true),
                    distrito = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    alergias_medicamentos = table.Column<string>(type: "text", nullable: true),
                    enfermedades_sistemicas = table.Column<string>(type: "text", nullable: true),
                    toma_medicamentos = table.Column<string>(type: "text", nullable: true),
                    tipo_sangre = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    presion_arterial = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    contacto_emergencia_nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    contacto_emergencia_telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    contacto_emergencia_parentesco = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tiene_seguro = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    nombre_seguro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    numero_poliza = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    fecha_registro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ultima_visita = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__paciente__2C2C72BBEB6FF6ED", x => x.id_paciente);
                });

            migrationBuilder.CreateTable(
                name: "tratamientos",
                columns: table => new
                {
                    id_tratamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    categoria = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    costo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    duracion_minutos = table.Column<int>(type: "int", nullable: true, defaultValue: 45),
                    sesiones_requeridas = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    requiere_anestesia = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tratamie__C8825F4C4710718D", x => x.id_tratamiento);
                });

            migrationBuilder.CreateTable(
                name: "odontologos",
                columns: table => new
                {
                    id_odontologo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    especialidad_id = table.Column<int>(type: "int", nullable: false),
                    numero_colegiatura = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    documento_identidad = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    consultorio_principal_id = table.Column<int>(type: "int", nullable: true),
                    color_agenda = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    tarifa_consulta = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    comision_porcentaje = table.Column<decimal>(type: "decimal(5,2)", nullable: true, defaultValue: 0m),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    fecha_registro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__odontolo__FBACF3EBFC41AFA1", x => x.id_odontologo);
                    table.ForeignKey(
                        name: "FK__odontolog__consu__3E52440B",
                        column: x => x.consultorio_principal_id,
                        principalTable: "consultorios",
                        principalColumn: "id_consultorio");
                    table.ForeignKey(
                        name: "FK__odontolog__espec__3D5E1FD2",
                        column: x => x.especialidad_id,
                        principalTable: "especialidades_odontologicas",
                        principalColumn: "id_especialidad");
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    rol = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    odontologo_id = table.Column<int>(type: "int", nullable: true),
                    nombres = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    apellidos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ultimo_acceso = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuarios__4E3E04AD573868FF", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK__usuarios__odonto__44FF419A",
                        column: x => x.odontologo_id,
                        principalTable: "odontologos",
                        principalColumn: "id_odontologo");
                });

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    id_cita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paciente_id = table.Column<int>(type: "int", nullable: false),
                    odontologo_id = table.Column<int>(type: "int", nullable: false),
                    consultorio_id = table.Column<int>(type: "int", nullable: true),
                    fecha_hora_inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_hora_fin = table.Column<DateTime>(type: "datetime", nullable: false),
                    estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "programada"),
                    motivo_consulta = table.Column<string>(type: "text", nullable: true),
                    tipo_cita = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "primera_vez"),
                    observaciones = table.Column<string>(type: "text", nullable: true),
                    tratamiento_realizado = table.Column<string>(type: "text", nullable: true),
                    proxima_cita = table.Column<DateOnly>(type: "date", nullable: true),
                    creado_por = table.Column<int>(type: "int", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__citas__6AEC3C090E1D7D7C", x => x.id_cita);
                    table.ForeignKey(
                        name: "FK__citas__consultor__4E88ABD4",
                        column: x => x.consultorio_id,
                        principalTable: "consultorios",
                        principalColumn: "id_consultorio");
                    table.ForeignKey(
                        name: "FK__citas__creado_po__4F7CD00D",
                        column: x => x.creado_por,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                    table.ForeignKey(
                        name: "FK__citas__odontolog__4D94879B",
                        column: x => x.odontologo_id,
                        principalTable: "odontologos",
                        principalColumn: "id_odontologo");
                    table.ForeignKey(
                        name: "FK__citas__paciente___4CA06362",
                        column: x => x.paciente_id,
                        principalTable: "pacientes",
                        principalColumn: "id_paciente");
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    id_pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cita_id = table.Column<int>(type: "int", nullable: true),
                    paciente_id = table.Column<int>(type: "int", nullable: false),
                    numero_comprobante = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tipo_comprobante = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "boleta"),
                    fecha_pago = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    razon_social = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ruc = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    descuento = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    igv = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: "pendiente"),
                    observaciones = table.Column<string>(type: "text", nullable: true),
                    registrado_por = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pagos__0941B074DAFD3429", x => x.id_pago);
                    table.ForeignKey(
                        name: "FK__pagos__cita_id__68487DD7",
                        column: x => x.cita_id,
                        principalTable: "citas",
                        principalColumn: "id_cita");
                    table.ForeignKey(
                        name: "FK__pagos__paciente___693CA210",
                        column: x => x.paciente_id,
                        principalTable: "pacientes",
                        principalColumn: "id_paciente");
                    table.ForeignKey(
                        name: "FK__pagos__registrad__6A30C649",
                        column: x => x.registrado_por,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateIndex(
                name: "idx_estado",
                table: "citas",
                column: "estado");

            migrationBuilder.CreateIndex(
                name: "idx_fecha",
                table: "citas",
                column: "fecha_hora_inicio");

            migrationBuilder.CreateIndex(
                name: "idx_odontologo",
                table: "citas",
                column: "odontologo_id");

            migrationBuilder.CreateIndex(
                name: "idx_paciente",
                table: "citas",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_citas_consultorio_id",
                table: "citas",
                column: "consultorio_id");

            migrationBuilder.CreateIndex(
                name: "IX_citas_creado_por",
                table: "citas",
                column: "creado_por");

            migrationBuilder.CreateIndex(
                name: "UQ__consulto__FC77F2115B289899",
                table: "consultorios",
                column: "numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__especial__72AFBCC61C4CE363",
                table: "especialidades_odontologicas",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__formas_p__72AFBCC65C6EF808",
                table: "formas_pago",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_especialidad",
                table: "odontologos",
                column: "especialidad_id");

            migrationBuilder.CreateIndex(
                name: "IX_odontologos_consultorio_principal_id",
                table: "odontologos",
                column: "consultorio_principal_id");

            migrationBuilder.CreateIndex(
                name: "UQ__odontolo__1A03B13F5FDF3768",
                table: "odontologos",
                column: "documento_identidad",
                unique: true,
                filter: "[documento_identidad] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__odontolo__D74701062376F6EC",
                table: "odontologos",
                column: "numero_colegiatura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_documento",
                table: "pacientes",
                column: "documento_identidad");

            migrationBuilder.CreateIndex(
                name: "idx_nombres",
                table: "pacientes",
                columns: new[] { "nombres", "apellidos" });

            migrationBuilder.CreateIndex(
                name: "idx_telefono",
                table: "pacientes",
                column: "telefono");

            migrationBuilder.CreateIndex(
                name: "UQ__paciente__1A03B13F460EF57C",
                table: "pacientes",
                column: "documento_identidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__paciente__AF36E77390726724",
                table: "pacientes",
                column: "numero_historia_clinica",
                unique: true,
                filter: "[numero_historia_clinica] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_estado_pago",
                table: "pagos",
                column: "estado");

            migrationBuilder.CreateIndex(
                name: "idx_fecha_pago",
                table: "pagos",
                column: "fecha_pago");

            migrationBuilder.CreateIndex(
                name: "idx_paciente_pago",
                table: "pagos",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_cita_id",
                table: "pagos",
                column: "cita_id");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_registrado_por",
                table: "pagos",
                column: "registrado_por");

            migrationBuilder.CreateIndex(
                name: "UQ__pagos__1850D80D813DF958",
                table: "pagos",
                column: "numero_comprobante",
                unique: true,
                filter: "[numero_comprobante] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_categoria",
                table: "tratamientos",
                column: "categoria");

            migrationBuilder.CreateIndex(
                name: "idx_codigo",
                table: "tratamientos",
                column: "codigo");

            migrationBuilder.CreateIndex(
                name: "UQ__tratamie__40F9A206B6614033",
                table: "tratamientos",
                column: "codigo",
                unique: true,
                filter: "[codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idx_username",
                table: "usuarios",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_odontologo_id",
                table: "usuarios",
                column: "odontologo_id");

            migrationBuilder.CreateIndex(
                name: "UQ__usuarios__F3DBC572E12B548A",
                table: "usuarios",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "formas_pago");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "tratamientos");

            migrationBuilder.DropTable(
                name: "citas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "pacientes");

            migrationBuilder.DropTable(
                name: "odontologos");

            migrationBuilder.DropTable(
                name: "consultorios");

            migrationBuilder.DropTable(
                name: "especialidades_odontologicas");
        }
    }
}
