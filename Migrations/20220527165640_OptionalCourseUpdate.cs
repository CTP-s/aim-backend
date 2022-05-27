using Microsoft.EntityFrameworkCore.Migrations;

namespace aim_backend.Migrations
{
    public partial class OptionalCourseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Approved",
                table: "Courses",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Courses");
        }
    }
}
