using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class DisponibilidadMedico : Migration
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
                name: "DisponibilidadMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    DiasSemanaId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadMedicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisponibilidadMedicos_DiasSemana_DiasSemanaId",
                        column: x => x.DiasSemanaId,
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

            migrationBuilder.InsertData(
                table: "DisponibilidadMedicos",
                columns: new[] { "Id", "DiasSemanaId", "EndTime", "MedicoId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 12, 0, 0, 0), 1, new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, 3, new TimeSpan(0, 16, 0, 0, 0), 1, new TimeSpan(0, 13, 0, 0, 0) },
                    { 3, 2, new TimeSpan(0, 14, 0, 0, 0), 2, new TimeSpan(0, 10, 0, 0, 0) },
                    { 4, 4, new TimeSpan(0, 12, 0, 0, 0), 3, new TimeSpan(0, 8, 0, 0, 0) },
                    { 5, 5, new TimeSpan(0, 18, 0, 0, 0), 3, new TimeSpan(0, 14, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadMedicos_DiasSemanaId",
                table: "DisponibilidadMedicos",
                column: "DiasSemanaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadMedicos_MedicoId",
                table: "DisponibilidadMedicos",
                column: "MedicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisponibilidadMedicos");

            migrationBuilder.DropTable(
                name: "DiasSemana");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 862, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 862, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 862, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 862, DateTimeKind.Local).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 867, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 867, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 867, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 871, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 3, 18, 34, 22, 871, DateTimeKind.Local).AddTicks(6232));
        }
    }
}
