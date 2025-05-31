using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Approved_on",
                table: "Dispatches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_on",
                table: "Dispatches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Creator_id",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Declined",
                table: "Dispatches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Declined_on",
                table: "Dispatches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dispatch_date",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Dispatched",
                table: "Dispatches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Document_id",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nmis_certificate",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Overall_weight",
                table: "Dispatches",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Pending",
                table: "Dispatches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Plate_no",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Product_id",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Production_date",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Dispatches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Reviewer_id",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Seal_no",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time_end",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time_start",
                table: "Dispatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Updated_id",
                table: "Dispatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_on",
                table: "Dispatches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Dispatched",
                table: "DispatchDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Dispatching_id",
                table: "DispatchDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pallet_number",
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

            migrationBuilder.AddColumn<int>(
                name: "Quantity_in_pallet",
                table: "DispatchDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceivingDetail_id",
                table: "DispatchDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Dispatches_Document_id",
                table: "Dispatches",
                column: "Document_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dispatches_Product_id",
                table: "Dispatches",
                column: "Product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DispatchDetails_Dispatching_id",
                table: "DispatchDetails",
                column: "Dispatching_id");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchDetails_Position_id",
                table: "DispatchDetails",
                column: "Position_id");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchDetails_ReceivingDetail_id",
                table: "DispatchDetails",
                column: "ReceivingDetail_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchDetails_Dispatches_Dispatching_id",
                table: "DispatchDetails",
                column: "Dispatching_id",
                principalTable: "Dispatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchDetails_PalletPositions_Position_id",
                table: "DispatchDetails",
                column: "Position_id",
                principalTable: "PalletPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchDetails_ReceivingDetails_ReceivingDetail_id",
                table: "DispatchDetails",
                column: "ReceivingDetail_id",
                principalTable: "ReceivingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispatches_Documents_Document_id",
                table: "Dispatches",
                column: "Document_id",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispatches_Products_Product_id",
                table: "Dispatches",
                column: "Product_id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchDetails_Dispatches_Dispatching_id",
                table: "DispatchDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DispatchDetails_PalletPositions_Position_id",
                table: "DispatchDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DispatchDetails_ReceivingDetails_ReceivingDetail_id",
                table: "DispatchDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Dispatches_Documents_Document_id",
                table: "Dispatches");

            migrationBuilder.DropForeignKey(
                name: "FK_Dispatches_Products_Product_id",
                table: "Dispatches");

            migrationBuilder.DropIndex(
                name: "IX_Dispatches_Document_id",
                table: "Dispatches");

            migrationBuilder.DropIndex(
                name: "IX_Dispatches_Product_id",
                table: "Dispatches");

            migrationBuilder.DropIndex(
                name: "IX_DispatchDetails_Dispatching_id",
                table: "DispatchDetails");

            migrationBuilder.DropIndex(
                name: "IX_DispatchDetails_Position_id",
                table: "DispatchDetails");

            migrationBuilder.DropIndex(
                name: "IX_DispatchDetails_ReceivingDetail_id",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "Approved_on",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Created_on",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Creator_id",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Declined",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Declined_on",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Dispatch_date",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Dispatched",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Document_id",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Nmis_certificate",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Overall_weight",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Pending",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Plate_no",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Product_id",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Production_date",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Reviewer_id",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Seal_no",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Time_end",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Time_start",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Updated_id",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Updated_on",
                table: "Dispatches");

            migrationBuilder.DropColumn(
                name: "Dispatched",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "Dispatching_id",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "Pallet_number",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "Position_id",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "Quantity_in_pallet",
                table: "DispatchDetails");

            migrationBuilder.DropColumn(
                name: "ReceivingDetail_id",
                table: "DispatchDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 28, 9, 10, 36, 336, DateTimeKind.Unspecified).AddTicks(5723), "$2a$11$2zhzn7/IwAN1KBoEDl3owOn9Kki2qiNAtpJdJ06L.5ZbJPuS89I.2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 28, 9, 10, 36, 493, DateTimeKind.Unspecified).AddTicks(6355), "$2a$11$M3Pmqrlqa.Z4DYq9NY1l0eQC3iU7U4JSSovYh2AzVQR4MVWq.ATCW" });
        }
    }
}
