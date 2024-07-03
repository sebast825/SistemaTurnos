using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class estados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoUsuarioId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoUsuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EstadoUsuarios",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" },
                    { 3, "Suspendido" },
                    { 4, "Eliminado" }
                });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 862, DateTimeKind.Local).AddTicks(3175) });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 862, DateTimeKind.Local).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 862, DateTimeKind.Local).AddTicks(5748) });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 862, DateTimeKind.Local).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 867, DateTimeKind.Local).AddTicks(1099) });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 867, DateTimeKind.Local).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 867, DateTimeKind.Local).AddTicks(1108) });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 871, DateTimeKind.Local).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EstadoUsuarioId", "FechaCreacion" },
                values: new object[] { 1, new DateTime(2024, 7, 3, 18, 34, 22, 871, DateTimeKind.Local).AddTicks(6232) });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EstadoUsuarioId",
                table: "Personas",
                column: "EstadoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_EstadoUsuarios_EstadoUsuarioId",
                table: "Personas",
                column: "EstadoUsuarioId",
                principalTable: "EstadoUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_EstadoUsuarios_EstadoUsuarioId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "EstadoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personas_EstadoUsuarioId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "EstadoUsuarioId",
                table: "Personas");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 453, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 453, DateTimeKind.Local).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 454, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 454, DateTimeKind.Local).AddTicks(44));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 457, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 457, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 457, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 459, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 13, 4, 18, 459, DateTimeKind.Local).AddTicks(7513));
        }
    }
}
