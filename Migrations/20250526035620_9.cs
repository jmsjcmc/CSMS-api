using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColdStorages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cs_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdStorages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dispatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pallet_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pallet_no = table.Column<int>(type: "int", nullable: false),
                    Occupied = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Removed = table.Column<bool>(type: "bit", nullable: false),
                    Creator_id = table.Column<int>(type: "int", nullable: false),
                    Created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_id = table.Column<int>(type: "int", nullable: true),
                    Updated_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PalletPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cs_id = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pallet_row = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pallet_column = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PalletPositions_ColdStorages_Cs_id",
                        column: x => x.Cs_id,
                        principalTable: "ColdStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document_id = table.Column<int>(type: "int", nullable: false),
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Expiration_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cv_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unloading_start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unloading_end = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overall_weight = table.Column<double>(type: "float", nullable: false),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Production_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator_id = table.Column<int>(type: "int", nullable: false),
                    Created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updater_id = table.Column<int>(type: "int", nullable: false),
                    Updated_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reviewer_id = table.Column<int>(type: "int", nullable: false),
                    Date_received = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_declined = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Receiving_form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pending = table.Column<bool>(type: "bit", nullable: false),
                    Received = table.Column<bool>(type: "bit", nullable: false),
                    Declined = table.Column<bool>(type: "bit", nullable: false),
                    Dispatched = table.Column<bool>(type: "bit", nullable: false),
                    Removed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivings_Documents_Document_id",
                        column: x => x.Document_id,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receivings_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receiving_id = table.Column<int>(type: "int", nullable: false),
                    Position_id = table.Column<int>(type: "int", nullable: false),
                    Pallet_number = table.Column<int>(type: "int", nullable: false),
                    Quantity_in_pallet = table.Column<int>(type: "int", nullable: false),
                    Total_weight = table.Column<double>(type: "float", nullable: false),
                    Received = table.Column<bool>(type: "bit", nullable: false),
                    Dispatched = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivingDetails_PalletPositions_Position_id",
                        column: x => x.Position_id,
                        principalTable: "PalletPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingDetails_Receivings_Receiving_id",
                        column: x => x.Receiving_id,
                        principalTable: "Receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PalletPositions_Cs_id",
                table: "PalletPositions",
                column: "Cs_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetails_Position_id",
                table: "ReceivingDetails",
                column: "Position_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetails_Receiving_id",
                table: "ReceivingDetails",
                column: "Receiving_id");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_Document_id",
                table: "Receivings",
                column: "Document_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_Product_id",
                table: "Receivings",
                column: "Product_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispatchDetails");

            migrationBuilder.DropTable(
                name: "Dispatches");

            migrationBuilder.DropTable(
                name: "Pallets");

            migrationBuilder.DropTable(
                name: "ReceivingDetails");

            migrationBuilder.DropTable(
                name: "PalletPositions");

            migrationBuilder.DropTable(
                name: "Receivings");

            migrationBuilder.DropTable(
                name: "ColdStorages");

            migrationBuilder.DropTable(
                name: "Documents");

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
    }
}
