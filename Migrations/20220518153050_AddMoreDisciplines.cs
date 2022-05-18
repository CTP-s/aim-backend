using Microsoft.EntityFrameworkCore.Migrations;

namespace aim_backend.Migrations
{
    public partial class AddMoreDisciplines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    teacherId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    maxNumberStudents = table.Column<int>(type: "INTEGER", nullable: true),
                    curriculumId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Curriculum_curriculumId",
                        column: x => x.curriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Users_teacherId",
                        column: x => x.teacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<int>(type: "INTEGER", nullable: true),
                    yearOfStudyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_studentId",
                        column: x => x.studentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_YearOfStudies_yearOfStudyId",
                        column: x => x.yearOfStudyId,
                        principalTable: "YearOfStudies",
                        principalColumn: "yearOfStudyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<int>(type: "INTEGER", nullable: true),
                    courseId = table.Column<int>(type: "INTEGER", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Users_studentId",
                        column: x => x.studentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCurricula",
                columns: table => new
                {
                    StudentCurriculumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<int>(type: "INTEGER", nullable: true),
                    curriculumId = table.Column<int>(type: "INTEGER", nullable: true),
                    optionalId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCurricula", x => x.StudentCurriculumId);
                    table.ForeignKey(
                        name: "FK_StudentCurricula_Courses_optionalId",
                        column: x => x.optionalId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCurricula_Curriculum_curriculumId",
                        column: x => x.curriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCurricula_Users_studentId",
                        column: x => x.studentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_curriculumId",
                table: "Courses",
                column: "curriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_teacherId",
                table: "Courses",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_studentId",
                table: "Enrollments",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_yearOfStudyId",
                table: "Enrollments",
                column: "yearOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_courseId",
                table: "Grades",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_studentId",
                table: "Grades",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCurricula_curriculumId",
                table: "StudentCurricula",
                column: "curriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCurricula_optionalId",
                table: "StudentCurricula",
                column: "optionalId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCurricula_studentId",
                table: "StudentCurricula",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "StudentCurricula");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
