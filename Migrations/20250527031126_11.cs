using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csms_api.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 27, 11, 11, 25, 794, DateTimeKind.Unspecified).AddTicks(9036), "$2a$11$R2QjMd.b6pGXnPcAjii.ROOGoztFfu2qbmk60DQwRVa8Jis7nfVOC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 26, 14, 40, 10, 603, DateTimeKind.Unspecified).AddTicks(4191), "$2a$11$PpSnRW0QW7Jno/ghGeKMfOEpML7MUDYlN1hVSuG6A6rm.nnS0VVNa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_on", "Password" },
                values: new object[] { new DateTime(2025, 5, 26, 14, 40, 10, 767, DateTimeKind.Unspecified).AddTicks(4095), "$2a$11$eqb24d9.LZaKC6DJ4lgby.abGc6xqRlOT8wMIa9l1ygau.RLXMODq" });
        }
    }
}
