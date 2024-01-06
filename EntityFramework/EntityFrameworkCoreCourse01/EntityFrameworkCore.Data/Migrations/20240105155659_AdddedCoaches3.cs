using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdddedCoaches3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
