using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Products",
                newName: "Removed");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_on",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Creator_id",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Companies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_on",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Updater_id",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BusinessUnits",
                columns: new[] { "Id", "BusinessUnit_location", "Business_unit", "Removed" },
                values: new object[,]
                {
                    { 1, "Sitio Sto.Nino, Brgy.Binugao, Toril, Davao City", "ABFI Central Office", false },
                    { 2, "Binugao, Toril, Davao City", "SubZero Ice and Cold Storage", false }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Removed", "Role_name" },
                values: new object[,]
                {
                    { 1, false, "Administrator" },
                    { 2, false, "User" },
                    { 3, false, "Approver" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BusinessUnit_id", "Created_on", "Department", "E_signature", "First_name", "Last_name", "Password", "Position", "Removed", "Role", "Updated_on", "Username" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 24, 13, 48, 20, 785, DateTimeKind.Unspecified).AddTicks(8514), "Cisdevo", null, "James Jecemeco", "Tabilog", "$2a$11$EZDl17a2nI1MZWw3kTFSiuMDGkm0zK40kImxFSmisnIm7p4EpFgDy", "Software Developer", false, "Administrator, User, Approver", null, "211072" },
                    { 2, 2, new DateTime(2025, 5, 24, 13, 48, 20, 943, DateTimeKind.Unspecified).AddTicks(9192), "Executive", null, "Shiela", "Hernando", "$2a$11$WwK8XJ226Hs2EuhUjKx5Nu3C.kYeiaXWJY2Te8txtvu4RalbZb/N.", "Senior Operations Manager", false, "Approver", null, "211072" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusinessUnits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BusinessUnits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Created_on",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Creator_id",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Updated_on",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Updater_id",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Removed",
                table: "Products",
                newName: "Deleted");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
