using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class medico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecialidadId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroLicencia",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Especialidad médica que se ocupa del estudio, diagnóstico y tratamiento de las enfermedades del corazón y del sistema circulatorio.", "Cardiología" },
                    { 2, "Especialidad médica que se encarga del estudio de la piel, su estructura, función y enfermedades.", "Dermatología" },
                    { 3, "Especialidad médica que se encarga del estudio, diagnóstico y tratamiento de las enfermedades del sistema nervioso.", "Neurología" }
                });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 22, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 22, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 23, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 23, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "EspecialidadId", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "NumeroLicencia", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 5, "Pérez", "Medico", "juan.perez@ejemplo.com", 1, new DateTime(2024, 7, 2, 12, 52, 35, 28, DateTimeKind.Local).AddTicks(6820), new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "DNI12345678", "LIC1234", 1, "123456789" },
                    { 6, "González", "Medico", "maria.gonzalez@ejemplo.com", 2, new DateTime(2024, 7, 2, 12, 52, 35, 28, DateTimeKind.Local).AddTicks(6827), new DateTime(1975, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "DNI87654321", "LIC5678", 2, "987654321" },
                    { 7, "López", "Medico", "carlos.lopez@ejemplo.com", 3, new DateTime(2024, 7, 2, 12, 52, 35, 28, DateTimeKind.Local).AddTicks(6833), new DateTime(1985, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", "DNI23456789", "LIC9101", 1, "555123456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EspecialidadId",
                table: "Personas",
                column: "EspecialidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Especialidades_EspecialidadId",
                table: "Personas",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Especialidades_EspecialidadId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropIndex(
                name: "IX_Personas_EspecialidadId",
                table: "Personas");

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "EspecialidadId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumeroLicencia",
                table: "Personas");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 19, 2, 25, 965, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 19, 2, 25, 965, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 19, 2, 25, 965, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 19, 2, 25, 965, DateTimeKind.Local).AddTicks(8276));
        }
    }
}
