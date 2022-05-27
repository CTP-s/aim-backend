﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aim_backend.Data;

namespace aim_backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220527165640_OptionalCourseUpdate")]
    partial class OptionalCourseUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("aim_backend.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Semester")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Course");
                });

            modelBuilder.Entity("aim_backend.Models.Curriculum", b =>
                {
                    b.Property<int>("CurriculumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearOfStudyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CurriculumId");

                    b.ToTable("Curriculum");
                });

            modelBuilder.Entity("aim_backend.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("aim_backend.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearOfStudyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EnrollmentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("aim_backend.Models.Faculty", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FacultyName")
                        .HasColumnType("TEXT");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("aim_backend.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("aim_backend.Models.StudentCurriculum", b =>
                {
                    b.Property<int>("StudentCurriculumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurriculumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OptionalCourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentCurriculumId");

                    b.ToTable("StudentCurricula");
                });

            modelBuilder.Entity("aim_backend.Models.StudyLine", b =>
                {
                    b.Property<int>("studyLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("studyLineName")
                        .HasColumnType("TEXT");

                    b.HasKey("studyLineId");

                    b.ToTable("StudyLines");
                });

            modelBuilder.Entity("aim_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("aim_backend.Models.YearOfStudy", b =>
                {
                    b.Property<int>("yearOfStudyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudyLineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("yearNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("yearOfStudyId");

                    b.ToTable("YearOfStudies");
                });

            modelBuilder.Entity("aim_backend.Models.OptionalCourse", b =>
                {
                    b.HasBaseType("aim_backend.Models.Course");

                    b.Property<int>("Approved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxNumberStudents")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("OptionalCourse");
                });

            modelBuilder.Entity("aim_backend.Models.RegularCourse", b =>
                {
                    b.HasBaseType("aim_backend.Models.Course");

                    b.Property<int>("CurriculumId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("RegularCourse");
                });

            modelBuilder.Entity("aim_backend.Models.Admin", b =>
                {
                    b.HasBaseType("aim_backend.Models.User");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("aim_backend.Models.Student", b =>
                {
                    b.HasBaseType("aim_backend.Models.User");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("aim_backend.Models.Teacher", b =>
                {
                    b.HasBaseType("aim_backend.Models.User");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FirstOptionalCourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SecondOptionalCourseId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
