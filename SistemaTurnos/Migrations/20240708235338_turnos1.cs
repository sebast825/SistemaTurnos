using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class turnos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_Personas_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Turnos_Personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 8, 20, 53, 37, 975, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.InsertData(
                table: "Turnos",
                columns: new[] { "Id", "Estado", "Fecha", "FechaCreacion", "MedicoId", "PacienteId" },
                values: new object[,]
                {
                    { 1, "Programada", new DateTime(2024, 7, 9, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(336), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(332), 5, 3 },
                    { 2, "Cancelada", new DateTime(2024, 7, 10, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(342), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(341), 6, 4 },
                    { 3, "Completada", new DateTime(2024, 7, 11, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(344), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(343), 7, 3 },
                    { 4, "LLamando", new DateTime(2024, 7, 12, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(346), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(345), 5, 4 },
                    { 5, "EnProgreso", new DateTime(2024, 7, 13, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(349), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(348), 6, 3 },
                    { 6, "Finalizada", new DateTime(2024, 7, 14, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(351), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(350), 7, 4 },
                    { 7, "NoAsistida", new DateTime(2024, 7, 15, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(353), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(352), 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_MedicoId",
                table: "Turnos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PacienteId",
                table: "Turnos",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

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
    }
}
