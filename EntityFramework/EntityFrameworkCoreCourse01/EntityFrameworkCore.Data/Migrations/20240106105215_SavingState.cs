using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SavingState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 6, 11, 47, 25, 174, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 6, 11, 47, 25, 174, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModifiedDate",
                value: new DateTime(2024, 1, 6, 11, 47, 25, 174, DateTimeKind.Local).AddTicks(6352));
        }
    }
}
