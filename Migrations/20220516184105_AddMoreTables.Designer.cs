﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aim_backend.Data;

namespace aim_backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220516184105_AddMoreTables")]
    partial class AddMoreTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("aim_backend.Models.Curriculum", b =>
                {
                    b.Property<int>("CurriculumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("yearOfStudyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CurriculumId");

                    b.HasIndex("yearOfStudyId");

                    b.ToTable("Curriculum");
                });

            modelBuilder.Entity("aim_backend.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("facultyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepartmentId");

                    b.HasIndex("facultyId");

                    b.ToTable("Departments");
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

            modelBuilder.Entity("aim_backend.Models.StudyLine", b =>
                {
                    b.Property<int>("studyLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("departmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("studyLineName")
                        .HasColumnType("TEXT");

                    b.HasKey("studyLineId");

                    b.HasIndex("departmentId");

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

                    b.Property<int?>("studyLineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("yearNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("yearOfStudyId");

                    b.HasIndex("studyLineId");

                    b.ToTable("YearOfStudies");
                });

            modelBuilder.Entity("aim_backend.Models.Admin", b =>
                {
                    b.HasBaseType("aim_backend.Models.User");

                    b.Property<int?>("facultyId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("facultyId");

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

                    b.Property<int>("FirstOptionalCourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SecondOptionalCourseId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("aim_backend.Models.Curriculum", b =>
                {
                    b.HasOne("aim_backend.Models.YearOfStudy", "YearOfStudy")
                        .WithMany()
                        .HasForeignKey("yearOfStudyId");

                    b.Navigation("YearOfStudy");
                });

            modelBuilder.Entity("aim_backend.Models.Department", b =>
                {
                    b.HasOne("aim_backend.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("facultyId");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("aim_backend.Models.StudyLine", b =>
                {
                    b.HasOne("aim_backend.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("departmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("aim_backend.Models.YearOfStudy", b =>
                {
                    b.HasOne("aim_backend.Models.StudyLine", "StudyLine")
                        .WithMany()
                        .HasForeignKey("studyLineId");

                    b.Navigation("StudyLine");
                });

            modelBuilder.Entity("aim_backend.Models.Admin", b =>
                {
                    b.HasOne("aim_backend.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("facultyId");

                    b.Navigation("Faculty");
                });
#pragma warning restore 612, 618
        }
    }
}
