using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace afh_be.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_UserID",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_UserID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Movies");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2024, 6, 18, 15, 13, 10, 639, DateTimeKind.Local).AddTicks(4170), null });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2024, 6, 23, 15, 13, 10, 639, DateTimeKind.Local).AddTicks(4170), null });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2024, 6, 28, 15, 13, 10, 639, DateTimeKind.Local).AddTicks(4170), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 8, 15, 13, 10, 639, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 13, 15, 13, 10, 639, DateTimeKind.Local).AddTicks(4090));

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserID",
                table: "Movies",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_UserID",
                table: "Movies",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
