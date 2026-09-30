using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AgregarProvinciasYPaises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 28, 15, 36, 3, 598, DateTimeKind.Unspecified).AddTicks(7423), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 28, 15, 36, 3, 598, DateTimeKind.Unspecified).AddTicks(7432), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 28, 15, 36, 3, 598, DateTimeKind.Unspecified).AddTicks(7434), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 8, 18, 0, 45, 459, DateTimeKind.Unspecified).AddTicks(7678), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 8, 18, 0, 45, 459, DateTimeKind.Unspecified).AddTicks(7745), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 8, 18, 0, 45, 459, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
