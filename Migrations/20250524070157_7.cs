using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created_on",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Creator_id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_on",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Updater_id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 1, 57, 288, DateTimeKind.Unspecified).AddTicks(8131), "$2a$11$UDXNAA1n4QT5IcjbXeMT7O4UKoTifCZ9aOo0yWil.YsyM8KoKXfwG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 1, 57, 459, DateTimeKind.Unspecified).AddTicks(1747), "$2a$11$daElJzzVqbusL9WJ3f33AOyvZeuRFcvLVly1m4vFEX/DhX6NBtVH6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_on",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Creator_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Updated_on",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Updater_id",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 54, 41, 913, DateTimeKind.Unspecified).AddTicks(9214), "$2a$11$Z/SY8p9hhkrG218NJL/nxus19fdT/Yl0qbY8leSASumUrjyl944qa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 54, 42, 72, DateTimeKind.Unspecified).AddTicks(7365), "$2a$11$.zLYmanpaakGKqtDSyN1IONqFTgMRXnPgzcLgGrS37e2QfTfBl/IS" });
        }
    }
}
