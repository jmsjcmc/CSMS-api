using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pallet_number",
                table: "ReceivingDetails",
                newName: "Pallet_id");

            migrationBuilder.RenameColumn(
                name: "Pallet_number",
                table: "DispatchDetails",
                newName: "Pallet_id");

            migrationBuilder.AddColumn<int>(
                name: "Position_id",
                table: "Pallets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_on",
                table: "Dispatches",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Updated_id",
                table: "Dispatches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Time_start",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Time_end",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Reviewer_id",
                table: "Dispatches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Approved_on",
                table: "Dispatches",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetails_Pallet_id",
                table: "ReceivingDetails",
                column: "Pallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pallets_Position_id",
                table: "Pallets",
                column: "Position_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DispatchDetails_Pallet_id",
                table: "DispatchDetails",
                column: "Pallet_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchDetails_Pallets_Pallet_id",
                table: "DispatchDetails",
                column: "Pallet_id",
                principalTable: "Pallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pallets_PalletPositions_Position_id",
                table: "Pallets",
                column: "Position_id",
                principalTable: "PalletPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingDetails_Pallets_Pallet_id",
                table: "ReceivingDetails",
                column: "Pallet_id",
                principalTable: "Pallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchDetails_Pallets_Pallet_id",
                table: "DispatchDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Pallets_PalletPositions_Position_id",
                table: "Pallets");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingDetails_Pallets_Pallet_id",
                table: "ReceivingDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingDetails_Pallet_id",
                table: "ReceivingDetails");

            migrationBuilder.DropIndex(
                name: "IX_Pallets_Position_id",
                table: "Pallets");

            migrationBuilder.DropIndex(
                name: "IX_DispatchDetails_Pallet_id",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "Position_id",
                table: "Pallets");

            migrationBuilder.RenameColumn(
                name: "Pallet_id",
                table: "ReceivingDetails",
                newName: "Pallet_number");

            migrationBuilder.RenameColumn(
                name: "Pallet_id",
                table: "DispatchDetails",
                newName: "Pallet_number");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_on",
                table: "Dispatches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Updated_id",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Time_start",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Time_end",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Reviewer_id",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Approved_on",
                table: "Dispatches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
