using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WaterTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterIntake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntakeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsumedWater = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterIntake", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterIntake_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "dannymaher@gmail.com", "Danny", "Maher" },
                    { 2, "sarahjenkins@gmail.com", "Sarah", "Jenkins" },
                    { 3, "mikesmith@gmail.com", "Mike", "Smith" },
                    { 4, "chloelee@gmail.com", "Chloe", "Lee" }
                });

            migrationBuilder.InsertData(
                table: "WaterIntake",
                columns: new[] { "Id", "ConsumedWater", "IntakeDate", "UserID" },
                values: new object[,]
                {
                    { 1, 5431, new DateTime(2023, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 10456, new DateTime(2023, 5, 3, 17, 24, 5, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 2234, new DateTime(2023, 8, 12, 12, 36, 51, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 67777, new DateTime(2023, 10, 23, 11, 17, 12, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 9967, new DateTime(2023, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 14566, new DateTime(2023, 5, 3, 18, 24, 5, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 23412, new DateTime(2023, 8, 15, 12, 36, 51, 0, DateTimeKind.Unspecified), 2 },
                    { 8, 17965, new DateTime(2023, 10, 23, 11, 17, 12, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 89233, new DateTime(2023, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 445556, new DateTime(2023, 5, 3, 19, 24, 5, 0, DateTimeKind.Unspecified), 3 },
                    { 11, 1965, new DateTime(2023, 8, 15, 12, 36, 51, 0, DateTimeKind.Unspecified), 3 },
                    { 12, 38563, new DateTime(2023, 10, 22, 11, 17, 12, 0, DateTimeKind.Unspecified), 3 },
                    { 13, 56238, new DateTime(2023, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), 4 },
                    { 14, 77796, new DateTime(2023, 5, 3, 22, 24, 5, 0, DateTimeKind.Unspecified), 4 },
                    { 15, 32145, new DateTime(2023, 8, 15, 12, 36, 51, 0, DateTimeKind.Unspecified), 4 },
                    { 16, 93485, new DateTime(2023, 10, 21, 11, 17, 12, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterIntake_UserID",
                table: "WaterIntake",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterIntake");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
