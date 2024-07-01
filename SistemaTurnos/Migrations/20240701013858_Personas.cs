using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class Personas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Hombre" },
                    { 2, "Mujer" },
                    { 3, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Email", "FechaNacimiento", "Nombre", "NumeroDocumento", "SexoId", "Telefono" },
                values: new object[,]
                {
                    { 1, "Pérez", "juan.perez@example.com", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", 12345678, 1, 123456789 },
                    { 2, "Gómez", "maria.gomez@example.com", new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", 87654321, 2, 987654321 },
                    { 3, "Rodríguez", "pedro.rodriguez@example.com", new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", 56781234, 1, 456789123 },
                    { 4, "Martínez", "ana.martinez@example.com", new DateTime(1995, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", 34567812, 2, 654321789 },
                    { 5, "Gutiérrez", "lucas.gutierrez@example.com", new DateTime(1987, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", 78123456, 1, 789123456 },
                    { 6, "López", "laura.lopez@example.com", new DateTime(1993, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", 23456781, 2, 321654987 },
                    { 7, "Sánchez", "gabriel.sanchez@example.com", new DateTime(1986, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel", 67812345, 1, 896745231 },
                    { 8, "Fernández", "carolina.fernandez@example.com", new DateTime(1991, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carolina", 45678123, 2, 478512369 },
                    { 9, "Díaz", "jorge.diaz@example.com", new DateTime(1989, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jorge", 56781234, 1, 369874512 },
                    { 10, "Ramírez", "valeria.ramirez@example.com", new DateTime(1994, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valeria", 67812345, 2, 214365879 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SexoId",
                table: "Personas",
                column: "SexoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Sexos");
        }
    }
}
