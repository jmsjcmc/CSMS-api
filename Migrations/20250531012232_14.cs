using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 31, 9, 22, 32, 264, DateTimeKind.Unspecified).AddTicks(3148), "$2a$11$1Jx.3RqUx6CFpuSvwuQy5eW9tXtr9sX3/OAwlNw2GnvHhSolxEKx2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 31, 9, 22, 32, 423, DateTimeKind.Unspecified).AddTicks(2171), "$2a$11$MpSIGY9gEBybvPodbAYCYOOJ7.cnvGZRGOpx229GNoVeOlR1fMdNK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 31, 9, 16, 5, 373, DateTimeKind.Unspecified).AddTicks(7968), "$2a$11$TFpCZNTqe1A1qV5IQV0kiei.53CyotcC.QhtCvuamSbaczfRrv6g." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 31, 9, 16, 5, 532, DateTimeKind.Unspecified).AddTicks(295), "$2a$11$sBYb6UZjOcsH5q0r6iZpVetXdCNo7Q.fZD3cBeElwzMcenTrZ24Va" });
        }
    }
}
