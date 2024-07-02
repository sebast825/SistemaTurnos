using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class Persona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "Persona", "juan.perez@example.com", new DateTime(2024, 7, 1, 18, 49, 57, 764, DateTimeKind.Local).AddTicks(7315), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 12345678, 1, 123456789 },
                    { 2, "Gómez", "Persona", "maria.gomez@example.com", new DateTime(2024, 7, 1, 18, 49, 57, 764, DateTimeKind.Local).AddTicks(7336), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", 87654321, 2, 987654321 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "FechaCreacion", "FechaNacimiento", "Nombre", "NombreEmergencia", "NumeroDocumento", "SexoId", "Telefono", "TelefonoEmergencia" },
                values: new object[,]
                {
                    { 1, "Pérez", "Paciente", "juan.perez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3149), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Ana Pérez", 12345678, 1, 123456789, "1122334455" },
                    { 2, "Gómez", "Paciente", "maria.gomez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3170), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "Carlos Gómez", 87654321, 2, 987654321, "2233445566" },
                    { 3, "Rodríguez", "Paciente", "pedro.rodriguez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3173), new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "Lucía Rodríguez", 56781234, 1, 456789123, "3344556677" },
                    { 4, "Martínez", "Paciente", "ana.martinez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3175), new DateTime(1995, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", "Miguel Martínez", 34567812, 2, 654321789, "4455667788" },
                    { 5, "Gutiérrez", "Paciente", "lucas.gutierrez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3177), new DateTime(1987, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", "Sofía Gutiérrez", 78123456, 1, 789123456, "5566778899" },
                    { 6, "López", "Paciente", "laura.lopez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3180), new DateTime(1993, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Juan López", 23456781, 2, 321654987, "6677889900" },
                    { 7, "Sánchez", "Paciente", "gabriel.sanchez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3182), new DateTime(1986, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel", "Elena Sánchez", 67812345, 1, 896745231, "7788990011" },
                    { 8, "Fernández", "Paciente", "carolina.fernandez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3184), new DateTime(1991, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carolina", "María Fernández", 45678123, 2, 478512369, "8899001122" },
                    { 9, "Díaz", "Paciente", "jorge.diaz@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3188), new DateTime(1989, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jorge", "Carlos Díaz", 56781234, 1, 369874512, "9900112233" },
                    { 10, "Ramírez", "Paciente", "valeria.ramirez@example.com", new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3237), new DateTime(1994, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valeria", "Ana Ramírez", 67812345, 2, 214365879, "0011223344" }
                });
        }
    }
}
