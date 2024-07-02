using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class paciente2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3173));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3188));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 34, 21, 576, DateTimeKind.Local).AddTicks(3237));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8227));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8235));
        }
    }
}
