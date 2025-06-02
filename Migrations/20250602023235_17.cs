using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchDetails_PalletPositions_Position_id",
                table: "DispatchDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingDetails_PalletPositions_Position_id",
                table: "ReceivingDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingDetails_Position_id",
                table: "ReceivingDetails");

            migrationBuilder.DropIndex(
                name: "IX_DispatchDetails_Position_id",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "Position_id",
                table: "ReceivingDetails");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Position_id",
                table: "ReceivingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetails_Position_id",
                table: "ReceivingDetails",
                column: "Position_id");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchDetails_Position_id",
                table: "DispatchDetails",
                column: "Position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchDetails_PalletPositions_Position_id",
                table: "DispatchDetails",
                column: "Position_id",
                principalTable: "PalletPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingDetails_PalletPositions_Position_id",
                table: "ReceivingDetails",
                column: "Position_id",
                principalTable: "PalletPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
