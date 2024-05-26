using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init_sule2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2364a830-8f52-4141-8dbf-7e14ddfe7eaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310bc244-4af0-4eb3-8c2f-c28f26ce7c0c");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c06030f-8483-4c64-b76a-12199f72465c", null, "Admin", "ADMIN" },
                    { "883b2ecd-e44e-4f40-94df-bd3886e03344", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c06030f-8483-4c64-b76a-12199f72465c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "883b2ecd-e44e-4f40-94df-bd3886e03344");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2364a830-8f52-4141-8dbf-7e14ddfe7eaa", null, "User", "USER" },
                    { "310bc244-4af0-4eb3-8c2f-c28f26ce7c0c", null, "Admin", "ADMIN" }
                });
        }
    }
}
