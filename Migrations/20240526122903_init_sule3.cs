using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init_sule3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c06030f-8483-4c64-b76a-12199f72465c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "883b2ecd-e44e-4f40-94df-bd3886e03344");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28db1ed5-3302-47bb-9f78-6b65f4d52509", null, "User", "USER" },
                    { "718e8088-d8e4-44d1-947a-f7985611adc8", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28db1ed5-3302-47bb-9f78-6b65f4d52509");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "718e8088-d8e4-44d1-947a-f7985611adc8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c06030f-8483-4c64-b76a-12199f72465c", null, "Admin", "ADMIN" },
                    { "883b2ecd-e44e-4f40-94df-bd3886e03344", null, "User", "USER" }
                });
        }
    }
}
