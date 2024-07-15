using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class inicialUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 15, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6516), new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6513) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 16, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6524), new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6523) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6526), new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6525) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 18, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6528), new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6527) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 19, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6531), new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 20, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6533), new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6532) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 21, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6535), new DateTime(2024, 7, 14, 21, 56, 47, 733, DateTimeKind.Local).AddTicks(6534) });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Password", "PersonaId", "UserName" },
                values: new object[,]
                {
                    { 1, "a", 1, "persona" },
                    { 2, "a", 3, "paciente" },
                    { 3, "a", 5, "medico" },
                    { 4, "a", 8, "secretario" },
                    { 5, "a", 9, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

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

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 9, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(336), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 10, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(342), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(341) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 11, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(344), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(343) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(346), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 13, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(349), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(348) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 14, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(351), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 15, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(353), new DateTime(2024, 7, 8, 20, 53, 37, 976, DateTimeKind.Local).AddTicks(352) });
        }
    }
}
