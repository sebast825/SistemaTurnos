using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class disponibilidadSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 25, 50, 695, DateTimeKind.Local).AddTicks(5308));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DisponibilidadMedicos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 16, 23, 46, 322, DateTimeKind.Local).AddTicks(8772));
        }
    }
}
