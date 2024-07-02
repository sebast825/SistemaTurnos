using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class Administrativo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Secretario" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "RolId", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 8, "Martínez", "Administrativo", "laura.martinez@ejemplo.com", new DateTime(2024, 7, 2, 13, 4, 18, 459, DateTimeKind.Local).AddTicks(7498), new DateTime(1990, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "DNI65432100", 1, 2, "111222333" },
                    { 9, "Sánchez", "Administrativo", "pedro.sanchez@ejemplo.com", new DateTime(2024, 7, 2, 13, 4, 18, 459, DateTimeKind.Local).AddTicks(7513), new DateTime(1982, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "DNI12345001", 2, 1, "444555666" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RolId",
                table: "Personas",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Roles_RolId",
                table: "Personas",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Roles_RolId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Personas_RolId",
                table: "Personas");

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Personas");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 22, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 22, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 23, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 23, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 28, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 28, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 2, 12, 52, 35, 28, DateTimeKind.Local).AddTicks(6833));
        }
    }
}
