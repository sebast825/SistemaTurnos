using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiasSemana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasSemana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoPersona = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroLicencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspecialidadId = table.Column<int>(type: "int", nullable: true),
                    TelefonoEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisponibilidadMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    DiaSemanaId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadMedicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisponibilidadMedicos_DiasSemana_DiaSemanaId",
                        column: x => x.DiaSemanaId,
                        principalTable: "DiasSemana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisponibilidadMedicos_Personas_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_Personas_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Turnos_Personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    EstadoUsuario = table.Column<int>(type: "int", nullable: false),
                    TokenRecovery = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DiasSemana",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Lunes" },
                    { 2, "Martes" },
                    { 3, "Miércoles" },
                    { 4, "Jueves" },
                    { 5, "Viernes" },
                    { 6, "Sábado" },
                    { 7, "Domingo" }
                });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Especialidad médica que se ocupa del estudio, diagnóstico y tratamiento de las enfermedades del corazón y del sistema circulatorio.", "Cardiología" },
                    { 2, "Especialidad médica que se encarga del estudio de la piel, su estructura, función y enfermedades.", "Dermatología" },
                    { 3, "Especialidad médica que se encarga del estudio, diagnóstico y tratamiento de las enfermedades del sistema nervioso.", "Neurología" }
                });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Hombre" },
                    { 2, "Mujer" },
                    { 3, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "EstadoPersona", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "Persona", 0, new DateTime(2024, 12, 29, 1, 4, 36, 638, DateTimeKind.Local).AddTicks(9888), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "12345678", 1, "123456789" },
                    { 2, "Gómez", "Persona", 0, new DateTime(2024, 12, 29, 1, 4, 36, 638, DateTimeKind.Local).AddTicks(9907), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "87654321", 2, "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "EstadoPersona", "FechaCreacion", "FechaNacimiento", "Nombre", "NombreEmergencia", "NumeroDocumento", "SexoId", "Telefono", "TelefonoEmergencia" },
                values: new object[,]
                {
                    { 3, "Pérez", "Paciente", 0, new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(2890), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Ana Pérez", "45345678", 1, "123452389", "1122334455" },
                    { 4, "Gómez", "Paciente", 0, new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(2903), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "Carlos Gómez", "12345678", 2, "123456756", "2233445566" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "EspecialidadId", "EstadoPersona", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "NumeroLicencia", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 5, "Pérez", "Medico", 1, 0, new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(3404), new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "DNI12345678", "LIC1234", 1, "123456789" },
                    { 6, "González", "Medico", 2, 0, new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(3408), new DateTime(1975, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "DNI87654321", "LIC5678", 2, "987654321" },
                    { 7, "López", "Medico", 3, 0, new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(3413), new DateTime(1985, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", "DNI23456789", "LIC9101", 1, "555123456" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "EstadoPersona", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 8, "Martínez", "Administrativo", 0, new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(4340), new DateTime(1990, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "DNI65432100", 2, "111222333" },
                    { 9, "Sánchez", "Administrativo", 0, new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(4347), new DateTime(1982, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "DNI12345001", 1, "444555666" }
                });

            migrationBuilder.InsertData(
                table: "DisponibilidadMedicos",
                columns: new[] { "Id", "DiaSemanaId", "EndTime", "MedicoId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 12, 0, 0, 0), 5, new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, 3, new TimeSpan(0, 16, 0, 0, 0), 5, new TimeSpan(0, 13, 0, 0, 0) },
                    { 3, 2, new TimeSpan(0, 14, 0, 0, 0), 6, new TimeSpan(0, 10, 0, 0, 0) },
                    { 4, 4, new TimeSpan(0, 12, 0, 0, 0), 7, new TimeSpan(0, 8, 0, 0, 0) },
                    { 5, 5, new TimeSpan(0, 18, 0, 0, 0), 7, new TimeSpan(0, 14, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Turnos",
                columns: new[] { "Id", "Estado", "Fecha", "FechaCreacion", "MedicoId", "PacienteId" },
                values: new object[,]
                {
                    { 1, "Programada", new DateTime(2024, 12, 30, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5550), new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5547), 5, 3 },
                    { 2, "Cancelada", new DateTime(2024, 12, 31, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5558), new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5557), 6, 4 },
                    { 3, "Completada", new DateTime(2025, 1, 1, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5561), new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5560), 7, 3 },
                    { 4, "LLamando", new DateTime(2025, 1, 2, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5564), new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5562), 5, 4 },
                    { 5, "EnProgreso", new DateTime(2025, 1, 3, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5567), new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5566), 6, 3 },
                    { 6, "Finalizada", new DateTime(2025, 1, 4, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5569), new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5568), 7, 4 },
                    { 7, "NoAsistida", new DateTime(2025, 1, 5, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5571), new DateTime(2024, 12, 29, 1, 4, 36, 639, DateTimeKind.Local).AddTicks(5570), 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "EstadoUsuario", "Password", "PersonaId", "Role", "TokenRecovery", "UserName" },
                values: new object[,]
                {
                    { 1, "persona@example.com", 0, "a", 1, 0, null, "persona" },
                    { 2, "paciente@example.com", 0, "a", 3, 0, null, "paciente" },
                    { 3, "medico@example.com", 0, "a", 5, 1, null, "medico" },
                    { 4, "secretario@example.com", 0, "a", 8, 2, null, "secretario" },
                    { 5, "admin@example.com", 0, "a", 9, 3, null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadMedicos_DiaSemanaId",
                table: "DisponibilidadMedicos",
                column: "DiaSemanaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadMedicos_MedicoId",
                table: "DisponibilidadMedicos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EspecialidadId",
                table: "Personas",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SexoId",
                table: "Personas",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_MedicoId",
                table: "Turnos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PacienteId",
                table: "Turnos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisponibilidadMedicos");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "DiasSemana");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Sexos");
        }
    }
}
