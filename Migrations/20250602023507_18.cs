using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchDetails_PalletPositions_PositionId",
                table: "DispatchDetails");

            migrationBuilder.DropIndex(
                name: "IX_DispatchDetails_PositionId",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "Position_id",
                table: "DispatchDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 35, 6, 954, DateTimeKind.Unspecified).AddTicks(1386), "$2a$11$99vcZAlUTQ5QlY2708g68.fmChGD6i6sbQtuYUVQDapfG/EiQ4uLm" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 35, 7, 118, DateTimeKind.Unspecified).AddTicks(3489), "$2a$11$h.6vHyODuK/YpKCjGtbJ/ec3PBEa2qyowlKzakSo3TPGBaB8iJ2bO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "DispatchDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position_id",
                table: "DispatchDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 32, 35, 194, DateTimeKind.Unspecified).AddTicks(7321), "$2a$11$.KV3K7VJG1LDvs79tjV7kejYZHKhctiglIkotqzaevAKhqv8zR6OS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 6, 2, 10, 32, 35, 368, DateTimeKind.Unspecified).AddTicks(4686), "$2a$11$iKxyPHzzTCk/UOAKtfETiuZ93127KW5i41pH82uE.SgzVRIyuIReq" });

            migrationBuilder.CreateIndex(
                name: "IX_DispatchDetails_PositionId",
                table: "DispatchDetails",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchDetails_PalletPositions_PositionId",
                table: "DispatchDetails",
                column: "PositionId",
                principalTable: "PalletPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
