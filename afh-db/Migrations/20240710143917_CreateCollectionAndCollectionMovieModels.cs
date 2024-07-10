using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace afh_be.Migrations
{
    /// <inheritdoc />
    public partial class CreateCollectionAndCollectionMovieModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionID);
                    table.ForeignKey(
                        name: "FK_Collections_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionMovies",
                columns: table => new
                {
                    CollectionID = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionMovies", x => new { x.CollectionID, x.MovieID });
                    table.ForeignKey(
                        name: "FK_CollectionMovies_Collections_CollectionID",
                        column: x => x.CollectionID,
                        principalTable: "Collections",
                        principalColumn: "CollectionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionMovies_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionID", "CreatedAt", "Description", "Name", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 10, 15, 39, 17, 153, DateTimeKind.Local).AddTicks(6630), "A list of the best ever movies.", "Best Movies", 1 },
                    { 2, new DateTime(2024, 7, 10, 15, 39, 17, 153, DateTimeKind.Local).AddTicks(6640), "A list of the worst ever movies.", "Worst Movies", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 20, 15, 39, 17, 153, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 25, 15, 39, 17, 153, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 30, 15, 39, 17, 153, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 15, 39, 17, 153, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 15, 15, 39, 17, 153, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.InsertData(
                table: "CollectionMovies",
                columns: new[] { "CollectionID", "MovieID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionMovies_MovieID",
                table: "CollectionMovies",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserID",
                table: "Collections",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionMovies");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Users",
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
    }
}
