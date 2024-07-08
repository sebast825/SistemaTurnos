using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class disonibilidadMedico2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisponibilidadMedicos_DiasSemana_DiasSemanaId",
                table: "DisponibilidadMedicos");

            migrationBuilder.RenameColumn(
                name: "DiasSemanaId",
                table: "DisponibilidadMedicos",
                newName: "DiaSemanaId");

            migrationBuilder.RenameIndex(
                name: "IX_DisponibilidadMedicos_DiasSemanaId",
                table: "DisponibilidadMedicos",
                newName: "IX_DisponibilidadMedicos_DiaSemanaId");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 170, DateTimeKind.Local).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 170, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 170, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 170, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 170, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 170, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 170, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 173, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 32, 40, 173, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.AddForeignKey(
                name: "FK_DisponibilidadMedicos_DiasSemana_DiaSemanaId",
                table: "DisponibilidadMedicos",
                column: "DiaSemanaId",
                principalTable: "DiasSemana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisponibilidadMedicos_DiasSemana_DiaSemanaId",
                table: "DisponibilidadMedicos");

            migrationBuilder.RenameColumn(
                name: "DiaSemanaId",
                table: "DisponibilidadMedicos",
                newName: "DiasSemanaId");

            migrationBuilder.RenameIndex(
                name: "IX_DisponibilidadMedicos_DiaSemanaId",
                table: "DisponibilidadMedicos",
                newName: "IX_DisponibilidadMedicos_DiasSemanaId");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 606, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 606, DateTimeKind.Local).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 606, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 606, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 606, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 606, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 606, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 609, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 7, 19, 10, 50, 609, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.AddForeignKey(
                name: "FK_DisponibilidadMedicos_DiasSemana_DiasSemanaId",
                table: "DisponibilidadMedicos",
                column: "DiasSemanaId",
                principalTable: "DiasSemana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
