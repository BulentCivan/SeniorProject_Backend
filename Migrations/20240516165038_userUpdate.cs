using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82085641-bb53-4899-8016-2748bca92e91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a92706d6-2e30-461f-8a5e-d5bbe272099c");

            migrationBuilder.DropColumn(
                name: "HasPsychologicalDisorder",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasPsychologicalDisorderMedicine",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasPsychologicalTreatment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Income",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsMarried",
                table: "AspNetUsers",
                newName: "ReceivingPsychoTreatment");

            migrationBuilder.RenameColumn(
                name: "HasUneaseMedicine",
                table: "AspNetUsers",
                newName: "PsychologicalCondition");

            migrationBuilder.RenameColumn(
                name: "HasUnease",
                table: "AspNetUsers",
                newName: "ChronicCondition");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "AspNetUsers",
                newName: "PsychologicalConditionMed");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "AspNetUsers",
                newName: "MonthlyIncome");

            migrationBuilder.RenameColumn(
                name: "Accomodation",
                table: "AspNetUsers",
                newName: "MarialStatus");

            migrationBuilder.AlterColumn<string>(
                name: "UserSurname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ChronicConditionMed",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChronicConditionName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationField",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongestResidence",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6995c33a-00ed-4f48-b931-db67cfead319", null, "User", "USER" },
                    { "ef399882-271e-4784-bb1a-98f9244cdedd", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6995c33a-00ed-4f48-b931-db67cfead319");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef399882-271e-4784-bb1a-98f9244cdedd");

            migrationBuilder.DropColumn(
                name: "ChronicConditionMed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChronicConditionName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EducationField",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EducationLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LongestResidence",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ReceivingPsychoTreatment",
                table: "AspNetUsers",
                newName: "IsMarried");

            migrationBuilder.RenameColumn(
                name: "PsychologicalConditionMed",
                table: "AspNetUsers",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "PsychologicalCondition",
                table: "AspNetUsers",
                newName: "HasUneaseMedicine");

            migrationBuilder.RenameColumn(
                name: "MonthlyIncome",
                table: "AspNetUsers",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "MarialStatus",
                table: "AspNetUsers",
                newName: "Accomodation");

            migrationBuilder.RenameColumn(
                name: "ChronicCondition",
                table: "AspNetUsers",
                newName: "HasUnease");

            migrationBuilder.AlterColumn<string>(
                name: "UserSurname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPsychologicalDisorder",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPsychologicalDisorderMedicine",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPsychologicalTreatment",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Income",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82085641-bb53-4899-8016-2748bca92e91", null, "Admin", "ADMIN" },
                    { "a92706d6-2e30-461f-8a5e-d5bbe272099c", null, "User", "USER" }
                });
        }
    }
}
