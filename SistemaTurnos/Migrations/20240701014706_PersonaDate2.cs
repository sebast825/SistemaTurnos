using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class PersonaDate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7359));

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Email", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "SexoId", "Telefono" },
                values: new object[] { 11, "Ramírez", "valeria.ramirez@example.com", new DateTime(2024, 6, 30, 22, 47, 6, 825, DateTimeKind.Local).AddTicks(7362), new DateTime(1993, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valeria", 67812345, 2, 214365879 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 45, 0, 961, DateTimeKind.Local).AddTicks(4649));
        }
    }
}
