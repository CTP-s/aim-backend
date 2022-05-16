using Microsoft.EntityFrameworkCore.Migrations;

namespace aim_backend.Migrations
{
    public partial class AddMoreTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Faculty_facultyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty");

            migrationBuilder.RenameTable(
                name: "Faculty",
                newName: "Faculties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties",
                column: "FacultyId");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentName = table.Column<string>(type: "TEXT", nullable: true),
                    facultyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_facultyId",
                        column: x => x.facultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyLines",
                columns: table => new
                {
                    studyLineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studyLineName = table.Column<string>(type: "TEXT", nullable: true),
                    departmentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyLines", x => x.studyLineId);
                    table.ForeignKey(
                        name: "FK_StudyLines_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YearOfStudies",
                columns: table => new
                {
                    yearOfStudyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    yearNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    studyLineId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearOfStudies", x => x.yearOfStudyId);
                    table.ForeignKey(
                        name: "FK_YearOfStudies_StudyLines_studyLineId",
                        column: x => x.studyLineId,
                        principalTable: "StudyLines",
                        principalColumn: "studyLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    CurriculumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    yearOfStudyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.CurriculumId);
                    table.ForeignKey(
                        name: "FK_Curriculum_YearOfStudies_yearOfStudyId",
                        column: x => x.yearOfStudyId,
                        principalTable: "YearOfStudies",
                        principalColumn: "yearOfStudyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_yearOfStudyId",
                table: "Curriculum",
                column: "yearOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_facultyId",
                table: "Departments",
                column: "facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyLines_departmentId",
                table: "StudyLines",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_YearOfStudies_studyLineId",
                table: "YearOfStudies",
                column: "studyLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Faculties_facultyId",
                table: "Users",
                column: "facultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Faculties_facultyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Curriculum");

            migrationBuilder.DropTable(
                name: "YearOfStudies");

            migrationBuilder.DropTable(
                name: "StudyLines");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties");

            migrationBuilder.RenameTable(
                name: "Faculties",
                newName: "Faculty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Faculty_facultyId",
                table: "Users",
                column: "facultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
