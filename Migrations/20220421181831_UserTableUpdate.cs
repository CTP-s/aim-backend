using Microsoft.EntityFrameworkCore.Migrations;

namespace aim_backend.Migrations
{
    public partial class UserTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "firstOptionalCourseId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "optionalCourseId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "secondOptionalCourseId",
                table: "Users",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstOptionalCourseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "optionalCourseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "secondOptionalCourseId",
                table: "Users");
        }
    }
}
