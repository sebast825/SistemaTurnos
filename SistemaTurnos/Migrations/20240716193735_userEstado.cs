using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class userEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 701, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 701, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3878), new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3875) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 18, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3885), new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3887), new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3886) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 20, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3889), new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3888) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 21, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3891), new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 22, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3894), new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3893) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 23, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3896), new DateTime(2024, 7, 16, 16, 37, 35, 702, DateTimeKind.Local).AddTicks(3895) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstadoUsuario",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 66, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 66, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3936), new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3933) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 18, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3944), new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3943) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3946), new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3945) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 20, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3949), new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 21, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3951), new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 22, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3953), new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3952) });

            migrationBuilder.UpdateData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Fecha", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 23, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3955), new DateTime(2024, 7, 16, 16, 35, 54, 67, DateTimeKind.Local).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstadoUsuario",
                value: 0);
        }
    }
}
