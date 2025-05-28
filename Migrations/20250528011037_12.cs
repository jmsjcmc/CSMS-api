using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Created_on", "Password", "Username" },
                values: new object[] { new DateTime(2025, 5, 28, 9, 10, 36, 493, DateTimeKind.Unspecified).AddTicks(6355), "$2a$11$M3Pmqrlqa.Z4DYq9NY1l0eQC3iU7U4JSSovYh2AzVQR4MVWq.ATCW", "211073" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 27, 11, 11, 25, 637, DateTimeKind.Unspecified).AddTicks(508), "$2a$11$pjjZ.E4Tp7wvfv8Xl8rVhegdOQcosIoPy144RcPUfZPMS7P967ZWW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password", "Username" },
                values: new object[] { new DateTime(2025, 5, 27, 11, 11, 25, 794, DateTimeKind.Unspecified).AddTicks(9036), "$2a$11$R2QjMd.b6pGXnPcAjii.ROOGoztFfu2qbmk60DQwRVa8Jis7nfVOC", "211072" });
        }
    }
}
