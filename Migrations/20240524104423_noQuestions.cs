using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class noQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "471f4839-f633-4e5e-b9b1-3f2ffc75227a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9972177d-36bb-4ac1-bf76-ebde33167515");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b5a8c4b-6846-4e1c-8970-66dff655fcdb", null, "Admin", "ADMIN" },
                    { "7706cad5-14ae-458d-b86a-c5e579247e6d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b5a8c4b-6846-4e1c-8970-66dff655fcdb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7706cad5-14ae-458d-b86a-c5e579247e6d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "471f4839-f633-4e5e-b9b1-3f2ffc75227a", null, "Admin", "ADMIN" },
                    { "9972177d-36bb-4ac1-bf76-ebde33167515", null, "User", "USER" }
                });
        }
    }
}
