using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 13, 22, 971, DateTimeKind.Unspecified).AddTicks(7675), "$2a$11$lZmJicW/AP.nUOeuy9B3hud7w4ZZF.obWspVxsMtJBDyvMd3lHFpu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 13, 23, 133, DateTimeKind.Unspecified).AddTicks(482), "$2a$11$aIUCC8IgeWHeE.Vsnw67gucCMdzW5/NXUwz58qxh16OXGbEYsxIYe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 9, 34, 44, 391, DateTimeKind.Unspecified).AddTicks(3552), "$2a$11$RALbultYp07dj6703XGnXeCSjGUzO2zkKHe.P/J53L0Khl31onGs2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 9, 34, 44, 549, DateTimeKind.Unspecified).AddTicks(7281), "$2a$11$./iGWzASCTVsCwzv/WjLbOldQYezl06FOfQG.zb2m2qUub9xdYhDK" });
        }
    }
}
