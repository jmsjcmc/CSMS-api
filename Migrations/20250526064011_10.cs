using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "PalletPositions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 26, 14, 40, 10, 603, DateTimeKind.Unspecified).AddTicks(4191), "$2a$11$PpSnRW0QW7Jno/ghGeKMfOEpML7MUDYlN1hVSuG6A6rm.nnS0VVNa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 26, 14, 40, 10, 767, DateTimeKind.Unspecified).AddTicks(4095), "$2a$11$eqb24d9.LZaKC6DJ4lgby.abGc6xqRlOT8wMIa9l1ygau.RLXMODq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Removed",
                table: "PalletPositions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 26, 11, 56, 19, 421, DateTimeKind.Unspecified).AddTicks(166), "$2a$11$s2qO2o2lVzKTiGC8rZavZesE6mJrnchVVJSq7e91KbFoHF8PJ2AX." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 26, 11, 56, 19, 599, DateTimeKind.Unspecified).AddTicks(2875), "$2a$11$.hdnhwYimqY6X3hKFM6lveobxvnVgXn2VjVqotzuiqIgEMk/2HzZy" });
        }
    }
}
