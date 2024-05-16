using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6995c33a-00ed-4f48-b931-db67cfead319");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef399882-271e-4784-bb1a-98f9244cdedd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cbbd3c8a-7aac-47c5-996f-d32a2b89dcbc", null, "User", "USER" },
                    { "f6d60f8d-fdb4-4d2b-a96a-109ef52c8161", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbbd3c8a-7aac-47c5-996f-d32a2b89dcbc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6d60f8d-fdb4-4d2b-a96a-109ef52c8161");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6995c33a-00ed-4f48-b931-db67cfead319", null, "User", "USER" },
                    { "ef399882-271e-4784-bb1a-98f9244cdedd", null, "Admin", "ADMIN" }
                });
        }
    }
}
