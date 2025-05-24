using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 11, 51, 963, DateTimeKind.Unspecified).AddTicks(1692), "$2a$11$u5O4T5JGfN8zlbfgMcKH3.Y2wPMf03tjoKQgzNvYKfRGv7V8UfgOO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 11, 52, 138, DateTimeKind.Unspecified).AddTicks(8365), "$2a$11$rcNsAoHGQ2y6CyTkNxz5ZuBtHy445iwmcuQg7O5DibqQ/WUC4ZLoK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
