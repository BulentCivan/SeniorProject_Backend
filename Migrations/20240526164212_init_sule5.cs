using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init_sule5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b5667ce-3a5c-48f2-971e-1c966a6cb139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9c65433-b7bd-47f5-b78d-b4b4972539c0");

            migrationBuilder.DropColumn(
                name: "Answers",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "Questions",
                table: "Tests",
                newName: "PatientEmail");

            migrationBuilder.CreateTable(
                name: "TestAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25de793a-e770-4252-b9c1-21b48467af07", null, "Admin", "ADMIN" },
                    { "af33c20c-c569-47d0-a07e-8e71568979fe", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25de793a-e770-4252-b9c1-21b48467af07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af33c20c-c569-47d0-a07e-8e71568979fe");

            migrationBuilder.RenameColumn(
                name: "PatientEmail",
                table: "Tests",
                newName: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Answers",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserTests",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTests", x => new { x.AppUserId, x.TestId });
                    table.ForeignKey(
                        name: "FK_UserTests_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b5667ce-3a5c-48f2-971e-1c966a6cb139", null, "Admin", "ADMIN" },
                    { "a9c65433-b7bd-47f5-b78d-b4b4972539c0", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_TestId",
                table: "UserTests",
                column: "TestId");
        }
    }
}
