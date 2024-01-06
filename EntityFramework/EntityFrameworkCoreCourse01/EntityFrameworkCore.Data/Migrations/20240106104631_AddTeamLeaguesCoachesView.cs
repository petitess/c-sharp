using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamLeaguesCoachesView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 6, 11, 46, 30, 771, DateTimeKind.Local).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 6, 11, 46, 30, 771, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 6, 11, 46, 30, 771, DateTimeKind.Local).AddTicks(3272));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 5, 16, 56, 58, 947, DateTimeKind.Local).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 5, 16, 56, 58, 947, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 5, 16, 56, 58, 947, DateTimeKind.Local).AddTicks(8418));
        }
    }
}
