using Microsoft.EntityFrameworkCore.Migrations;

namespace aim_backend.Migrations
{
    public partial class ChangeInCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Curriculum_curriculumId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Curriculum_YearOfStudies_yearOfStudyId",
                table: "Curriculum");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_facultyId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_studentId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_YearOfStudies_yearOfStudyId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_courseId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Users_studentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCurricula_Courses_optionalId",
                table: "StudentCurricula");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCurricula_Curriculum_curriculumId",
                table: "StudentCurricula");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCurricula_Users_studentId",
                table: "StudentCurricula");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyLines_Departments_departmentId",
                table: "StudyLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Faculties_facultyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_YearOfStudies_StudyLines_studyLineId",
                table: "YearOfStudies");

            migrationBuilder.DropIndex(
                name: "IX_YearOfStudies_studyLineId",
                table: "YearOfStudies");

            migrationBuilder.DropIndex(
                name: "IX_Users_facultyId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StudyLines_departmentId",
                table: "StudyLines");

            migrationBuilder.DropIndex(
                name: "IX_StudentCurricula_curriculumId",
                table: "StudentCurricula");

            migrationBuilder.DropIndex(
                name: "IX_StudentCurricula_optionalId",
                table: "StudentCurricula");

            migrationBuilder.DropIndex(
                name: "IX_StudentCurricula_studentId",
                table: "StudentCurricula");

            migrationBuilder.DropIndex(
                name: "IX_Grades_courseId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_studentId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_studentId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_yearOfStudyId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_facultyId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Curriculum_yearOfStudyId",
                table: "Curriculum");

            migrationBuilder.DropIndex(
                name: "IX_Courses_curriculumId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "optionalId",
                table: "StudentCurricula");

            migrationBuilder.RenameColumn(
                name: "studyLineId",
                table: "YearOfStudies",
                newName: "StudyLineId");

            migrationBuilder.RenameColumn(
                name: "facultyId",
                table: "Users",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "departmentId",
                table: "StudyLines",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "StudentCurricula",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "curriculumId",
                table: "StudentCurricula",
                newName: "CurriculumId");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Grades",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "Grades",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "yearOfStudyId",
                table: "Enrollments",
                newName: "YearOfStudyId");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Enrollments",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "facultyId",
                table: "Departments",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "yearOfStudyId",
                table: "Curriculum",
                newName: "YearOfStudyId");

            migrationBuilder.RenameColumn(
                name: "maxNumberStudents",
                table: "Courses",
                newName: "MaxNumberStudents");

            migrationBuilder.RenameColumn(
                name: "curriculumId",
                table: "Courses",
                newName: "CurriculumId");

            migrationBuilder.AlterColumn<int>(
                name: "StudyLineId",
                table: "YearOfStudies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "StudyLines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentCurricula",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurriculumId",
                table: "StudentCurricula",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptionalCourseId",
                table: "StudentCurricula",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Grades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Grades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearOfStudyId",
                table: "Enrollments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Enrollments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacultyId",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearOfStudyId",
                table: "Curriculum",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OptionalCourseId",
                table: "StudentCurricula");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StudyLineId",
                table: "YearOfStudies",
                newName: "studyLineId");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Users",
                newName: "facultyId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "StudyLines",
                newName: "departmentId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentCurricula",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "CurriculumId",
                table: "StudentCurricula",
                newName: "curriculumId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Grades",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Grades",
                newName: "courseId");

            migrationBuilder.RenameColumn(
                name: "YearOfStudyId",
                table: "Enrollments",
                newName: "yearOfStudyId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Enrollments",
                newName: "studentId");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Departments",
                newName: "facultyId");

            migrationBuilder.RenameColumn(
                name: "YearOfStudyId",
                table: "Curriculum",
                newName: "yearOfStudyId");

            migrationBuilder.RenameColumn(
                name: "MaxNumberStudents",
                table: "Courses",
                newName: "maxNumberStudents");

            migrationBuilder.RenameColumn(
                name: "CurriculumId",
                table: "Courses",
                newName: "curriculumId");

            migrationBuilder.AlterColumn<int>(
                name: "studyLineId",
                table: "YearOfStudies",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "departmentId",
                table: "StudyLines",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "StudentCurricula",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "curriculumId",
                table: "StudentCurricula",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "optionalId",
                table: "StudentCurricula",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "Grades",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "courseId",
                table: "Grades",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "yearOfStudyId",
                table: "Enrollments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "Enrollments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "facultyId",
                table: "Departments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "yearOfStudyId",
                table: "Curriculum",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_YearOfStudies_studyLineId",
                table: "YearOfStudies",
                column: "studyLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_facultyId",
                table: "Users",
                column: "facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyLines_departmentId",
                table: "StudyLines",
                column: "departmentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Grades_courseId",
                table: "Grades",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_studentId",
                table: "Grades",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_studentId",
                table: "Enrollments",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_yearOfStudyId",
                table: "Enrollments",
                column: "yearOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_facultyId",
                table: "Departments",
                column: "facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_yearOfStudyId",
                table: "Curriculum",
                column: "yearOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_curriculumId",
                table: "Courses",
                column: "curriculumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Curriculum_curriculumId",
                table: "Courses",
                column: "curriculumId",
                principalTable: "Curriculum",
                principalColumn: "CurriculumId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curriculum_YearOfStudies_yearOfStudyId",
                table: "Curriculum",
                column: "yearOfStudyId",
                principalTable: "YearOfStudies",
                principalColumn: "yearOfStudyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_facultyId",
                table: "Departments",
                column: "facultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_studentId",
                table: "Enrollments",
                column: "studentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_YearOfStudies_yearOfStudyId",
                table: "Enrollments",
                column: "yearOfStudyId",
                principalTable: "YearOfStudies",
                principalColumn: "yearOfStudyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_courseId",
                table: "Grades",
                column: "courseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Users_studentId",
                table: "Grades",
                column: "studentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCurricula_Courses_optionalId",
                table: "StudentCurricula",
                column: "optionalId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCurricula_Curriculum_curriculumId",
                table: "StudentCurricula",
                column: "curriculumId",
                principalTable: "Curriculum",
                principalColumn: "CurriculumId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCurricula_Users_studentId",
                table: "StudentCurricula",
                column: "studentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyLines_Departments_departmentId",
                table: "StudyLines",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Faculties_facultyId",
                table: "Users",
                column: "facultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YearOfStudies_StudyLines_studyLineId",
                table: "YearOfStudies",
                column: "studyLineId",
                principalTable: "StudyLines",
                principalColumn: "studyLineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
