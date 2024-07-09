using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace afh_be.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMovieIdToAutoIncrement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 18, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 28, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 8, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 13, 16, 14, 58, 526, DateTimeKind.Local).AddTicks(4920));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 18, 15, 17, 52, 306, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 15, 17, 52, 306, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 28, 15, 17, 52, 306, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 8, 15, 17, 52, 306, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 13, 15, 17, 52, 306, DateTimeKind.Local).AddTicks(4490));
        }
    }
}
