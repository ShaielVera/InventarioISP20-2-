using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_localidades_a_clientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Created_at", "Dni", "Firstname", "Lastname", "LocalidadId" },
                values: new object[] { "N.Zamaro 2559", new DateTimeOffset(new DateTime(2026, 9, 8, 18, 0, 45, 459, DateTimeKind.Unspecified).AddTicks(7678), new TimeSpan(0, -3, 0, 0, 0)), "44496912", "Shaiel", "Vera", 1 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 8, 18, 0, 45, 459, DateTimeKind.Unspecified).AddTicks(7745), new TimeSpan(0, -3, 0, 0, 0)), 2 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 8, 18, 0, 45, 459, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, -3, 0, 0, 0)), 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Created_at", "Dni", "Firstname", "Lastname", "LocalidadId" },
                values: new object[] { "Calle Falsa 123", new DateTimeOffset(new DateTime(2026, 9, 3, 19, 42, 51, 870, DateTimeKind.Unspecified).AddTicks(9389), new TimeSpan(0, -3, 0, 0, 0)), "12345678", "Juan", "Pérez", 0 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 3, 19, 42, 51, 870, DateTimeKind.Unspecified).AddTicks(9448), new TimeSpan(0, -3, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 3, 19, 42, 51, 870, DateTimeKind.Unspecified).AddTicks(9452), new TimeSpan(0, -3, 0, 0, 0)), 0 });
        }
    }
}
