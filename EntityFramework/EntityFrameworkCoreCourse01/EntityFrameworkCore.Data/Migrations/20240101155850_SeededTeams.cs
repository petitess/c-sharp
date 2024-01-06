using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Teams",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Coaches",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 15, 58, 50, 265, DateTimeKind.Unspecified).AddTicks(557), "Tivoli Gardens F.C." },
                    { 2, new DateTime(2024, 1, 1, 15, 58, 50, 265, DateTimeKind.Unspecified).AddTicks(563), "Waterhouse F.C." },
                    { 3, new DateTime(2024, 1, 1, 15, 58, 50, 265, DateTimeKind.Unspecified).AddTicks(564), "Humble Lions F.C." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedDate",
                table: "Teams",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedDate",
                table: "Coaches",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }
    }
}
