using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class persona2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Especialidades_EspecialidadId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Roles_RolId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Personas_EspecialidadId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_RolId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "EspecialidadId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumeroLicencia",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Personas");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 56, 47, 275, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 56, 47, 275, DateTimeKind.Local).AddTicks(3786));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecialidadId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroLicencia",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

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
                value: new DateTime(2024, 7, 1, 18, 49, 57, 764, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 1, 18, 49, 57, 764, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EspecialidadId",
                table: "Personas",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RolId",
                table: "Personas",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Especialidades_EspecialidadId",
                table: "Personas",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Roles_RolId",
                table: "Personas",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
