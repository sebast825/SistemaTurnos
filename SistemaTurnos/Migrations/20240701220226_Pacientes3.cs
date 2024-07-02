using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class Pacientes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDocumento",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "NumeroDocumento", "Telefono" },
                values: new object[] { new DateTime(2024, 7, 1, 19, 2, 25, 965, DateTimeKind.Local).AddTicks(6432), "12345678", "123456789" });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "NumeroDocumento", "Telefono" },
                values: new object[] { new DateTime(2024, 7, 1, 19, 2, 25, 965, DateTimeKind.Local).AddTicks(6446), "87654321", "987654321" });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "FechaCreacion", "FechaNacimiento", "Nombre", "NombreEmergencia", "NumeroDocumento", "SexoId", "Telefono", "TelefonoEmergencia" },
                values: new object[,]
                {
                    { 3, "Pérez", "Paciente", "juan.perez@example.com", new DateTime(2024, 7, 1, 19, 2, 25, 965, DateTimeKind.Local).AddTicks(8267), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Ana Pérez", "45345678", 1, "123452389", "1122334455" },
                    { 4, "Gómez", "Paciente", "maria.gomez@example.com", new DateTime(2024, 7, 1, 19, 2, 25, 965, DateTimeKind.Local).AddTicks(8276), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "Carlos Gómez", "12345678", 2, "123456756", "2233445566" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "Personas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroDocumento",
                table: "Personas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "NumeroDocumento", "Telefono" },
                values: new object[] { new DateTime(2024, 7, 1, 18, 56, 47, 275, DateTimeKind.Local).AddTicks(3769), 12345678, 123456789 });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "NumeroDocumento", "Telefono" },
                values: new object[] { new DateTime(2024, 7, 1, 18, 56, 47, 275, DateTimeKind.Local).AddTicks(3786), 87654321, 987654321 });
        }
    }
}
