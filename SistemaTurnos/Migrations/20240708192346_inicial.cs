﻿using System;
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
                name: "EstadoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Personas_EstadoUsuarios_EstadoUsuarioId",
                        column: x => x.EstadoUsuarioId,
                        principalTable: "EstadoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
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

            migrationBuilder.InsertData(
                table: "DiasSemana",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Lunes" },
                    { 2, "Martes" },
                    { 3, "Miercoles" },
                    { 4, "Jueves" },
                    { 5, "Viernes" },
                    { 6, "Sabado" },
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
                table: "EstadoUsuarios",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" },
                    { 3, "Suspendido" },
                    { 4, "Eliminado" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Secretario" }
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
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "EstadoUsuarioId", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "Persona", "juan.perez@example.com", 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(3913), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "12345678", 1, "123456789" },
                    { 2, "Gómez", "Persona", "maria.gomez@example.com", 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(3960), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "87654321", 2, "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "EstadoUsuarioId", "FechaCreacion", "FechaNacimiento", "Nombre", "NombreEmergencia", "NumeroDocumento", "SexoId", "Telefono", "TelefonoEmergencia" },
                values: new object[,]
                {
                    { 3, "Pérez", "Paciente", "juan.perez@example.com", 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(7879), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Ana Pérez", "45345678", 1, "123452389", "1122334455" },
                    { 4, "Gómez", "Paciente", "maria.gomez@example.com", 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(7889), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "Carlos Gómez", "12345678", 2, "123456756", "2233445566" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "EspecialidadId", "EstadoUsuarioId", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "NumeroLicencia", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 5, "Pérez", "Medico", "juan.perez@ejemplo.com", 1, 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8207), new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "DNI12345678", "LIC1234", 1, "123456789" },
                    { 6, "González", "Medico", "maria.gonzalez@ejemplo.com", 2, 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8210), new DateTime(1975, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "DNI87654321", "LIC5678", 2, "987654321" },
                    { 7, "López", "Medico", "carlos.lopez@ejemplo.com", 3, 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8213), new DateTime(1985, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", "DNI23456789", "LIC9101", 1, "555123456" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "EstadoUsuarioId", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "RolId", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 8, "Martínez", "Administrativo", "laura.martinez@ejemplo.com", 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8768), new DateTime(1990, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "DNI65432100", 1, 2, "111222333" },
                    { 9, "Sánchez", "Administrativo", "pedro.sanchez@ejemplo.com", 1, new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8772), new DateTime(1982, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "DNI12345001", 2, 1, "444555666" }
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
                name: "IX_Personas_EstadoUsuarioId",
                table: "Personas",
                column: "EstadoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RolId",
                table: "Personas",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SexoId",
                table: "Personas",
                column: "SexoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisponibilidadMedicos");

            migrationBuilder.DropTable(
                name: "DiasSemana");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "EstadoUsuarios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sexos");
        }
    }
}