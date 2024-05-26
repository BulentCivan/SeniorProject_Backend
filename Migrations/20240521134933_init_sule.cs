using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init_sule : Migration
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
                    { "2364a830-8f52-4141-8dbf-7e14ddfe7eaa", null, "User", "USER" },
                    { "310bc244-4af0-4eb3-8c2f-c28f26ce7c0c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2364a830-8f52-4141-8dbf-7e14ddfe7eaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310bc244-4af0-4eb3-8c2f-c28f26ce7c0c");

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
