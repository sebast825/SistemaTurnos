using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class disponibilidadMedicoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 1,
                column: "MedicoId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 2,
                column: "MedicoId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 3,
                column: "MedicoId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 4,
                column: "MedicoId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 5,
                column: "MedicoId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 881, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 881, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 882, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 882, DateTimeKind.Local).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 882, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 882, DateTimeKind.Local).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 882, DateTimeKind.Local).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 882, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 39, 43, 882, DateTimeKind.Local).AddTicks(2387));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 1,
                column: "MedicoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 2,
                column: "MedicoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 3,
                column: "MedicoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 4,
                column: "MedicoId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 5,
                column: "MedicoId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 75, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 75, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 76, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 76, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 76, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 76, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 76, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 76, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 13, 29, 37, 76, DateTimeKind.Local).AddTicks(2416));
        }
    }
}
