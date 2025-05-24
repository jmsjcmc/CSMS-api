using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 20, 785, DateTimeKind.Unspecified).AddTicks(8514), "$2a$11$EZDl17a2nI1MZWw3kTFSiuMDGkm0zK40kImxFSmisnIm7p4EpFgDy" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 24, 13, 48, 20, 943, DateTimeKind.Unspecified).AddTicks(9192), "$2a$11$WwK8XJ226Hs2EuhUjKx5Nu3C.kYeiaXWJY2Te8txtvu4RalbZb/N." });
        }
    }
}
