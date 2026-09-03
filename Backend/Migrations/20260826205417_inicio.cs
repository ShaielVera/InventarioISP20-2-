using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Dni = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Address", "Created_at", "Dni", "Firstname", "IsDeleted", "Lastname" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123", new DateTimeOffset(new DateTime(2026, 8, 26, 17, 54, 17, 718, DateTimeKind.Unspecified).AddTicks(3363), new TimeSpan(0, -3, 0, 0, 0)), "12345678", "Juan", false, "Pérez" },
                    { 2, "Avenida Siempre Viva 456", new DateTimeOffset(new DateTime(2026, 8, 26, 17, 54, 17, 718, DateTimeKind.Unspecified).AddTicks(3406), new TimeSpan(0, -3, 0, 0, 0)), "87654321", "María", false, "González" },
                    { 3, "Callejón del Beso 789", new DateTimeOffset(new DateTime(2026, 8, 26, 17, 54, 17, 718, DateTimeKind.Unspecified).AddTicks(3408), new TimeSpan(0, -3, 0, 0, 0)), "11223344", "Pedro", false, "López" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
