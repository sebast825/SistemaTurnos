using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class Pacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreEmergencia",
                table: "Personas",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<string>(
                name: "TelefonoEmergencia",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "FechaCreacion", "FechaNacimiento", "Nombre", "NombreEmergencia", "NumeroDocumento", "SexoId", "Telefono", "TelefonoEmergencia" },
                values: new object[,]
                {
                    { 1, "Pérez", "Paciente", "juan.perez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8201), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "Ana Pérez", 12345678, 1, 123456789, "1122334455" },
                    { 2, "Gómez", "Paciente", "maria.gomez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8217), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "Carlos Gómez", 87654321, 2, 987654321, "2233445566" },
                    { 3, "Rodríguez", "Paciente", "pedro.rodriguez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8220), new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "Lucía Rodríguez", 56781234, 1, 456789123, "3344556677" },
                    { 4, "Martínez", "Paciente", "ana.martinez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8222), new DateTime(1995, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", "Miguel Martínez", 34567812, 2, 654321789, "4455667788" },
                    { 5, "Gutiérrez", "Paciente", "lucas.gutierrez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8224), new DateTime(1987, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", "Sofía Gutiérrez", 78123456, 1, 789123456, "5566778899" },
                    { 6, "López", "Paciente", "laura.lopez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8227), new DateTime(1993, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Juan López", 23456781, 2, 321654987, "6677889900" },
                    { 7, "Sánchez", "Paciente", "gabriel.sanchez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8229), new DateTime(1986, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel", "Elena Sánchez", 67812345, 1, 896745231, "7788990011" },
                    { 8, "Fernández", "Paciente", "carolina.fernandez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8231), new DateTime(1991, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carolina", "María Fernández", 45678123, 2, 478512369, "8899001122" },
                    { 9, "Díaz", "Paciente", "jorge.diaz@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8233), new DateTime(1989, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jorge", "Carlos Díaz", 56781234, 1, 369874512, "9900112233" },
                    { 10, "Ramírez", "Paciente", "valeria.ramirez@example.com", new DateTime(2024, 7, 1, 18, 28, 14, 427, DateTimeKind.Local).AddTicks(8235), new DateTime(1994, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valeria", "Ana Ramírez", 67812345, 2, 214365879, "0011223344" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "EspecialidadId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NombreEmergencia",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumeroLicencia",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TelefonoEmergencia",
                table: "Personas");

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Email", "FechaCreacion", "FechaNacimiento", "Nombre", "NumeroDocumento", "SexoId", "Telefono" },
                values: new object[] { 11, "Ramírez", "valeria.ramirez@example.com", new DateTime(2024, 6, 30, 22, 53, 49, 113, DateTimeKind.Local).AddTicks(8202), new DateTime(1993, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valeria", 67812345, 2, 214365879 });
        }
    }
}
