﻿// <auto-generated />
using System;
using ExamSystemEF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamSystemEF.Migrations
{
    [DbContext(typeof(ExamSystemContext))]
    [Migration("20230315183659_gradeAdded")]
    partial class gradeAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExamSystemEF.Models.Choice", b =>
                {
                    b.Property<int>("Qu_Id")
                        .HasColumnType("int");

                    b.Property<string>("Qu_Choice")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Qu_Id", "Qu_Choice");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Course", b =>
                {
                    b.Property<int>("Crs_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Crs_Id"));

                    b.Property<string>("Crs_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvaluationPercent")
                        .HasColumnType("int");

                    b.Property<int>("Ins_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Crs_Id");

                    b.HasIndex("Ins_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Department", b =>
                {
                    b.Property<int>("Dept_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dept_Id"));

                    b.Property<string>("Dept_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Dept_Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Exam", b =>
                {
                    b.Property<int>("Ex_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ex_Id"));

                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int>("Ex_FullMark")
                        .HasColumnType("int");

                    b.HasKey("Ex_Id");

                    b.HasIndex("Crs_Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Instructor", b =>
                {
                    b.Property<int>("Ins_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ins_Id"));

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Ins_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ins_Salary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ins_Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Question", b =>
                {
                    b.Property<int>("Qu_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Qu_Id"));

                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<string>("Qu_Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qu_Mark")
                        .HasColumnType("int");

                    b.Property<string>("Qu_ModelAns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qu_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Qu_Id");

                    b.HasIndex("Crs_Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Student", b =>
                {
                    b.Property<int>("St_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("St_Id"));

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("St_DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("St_Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("St_Lname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("St_Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Student_Answer", b =>
                {
                    b.Property<int>("St_Id")
                        .HasColumnType("int");

                    b.Property<int>("Ex_Id")
                        .HasColumnType("int");

                    b.Property<int>("Qu_Id")
                        .HasColumnType("int");

                    b.Property<string>("St_Ans")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("St_Id", "Ex_Id", "Qu_Id");

                    b.HasIndex("Ex_Id");

                    b.HasIndex("Qu_Id");

                    b.ToTable("Student_Answers");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Student_Course", b =>
                {
                    b.Property<int>("St_Id")
                        .HasColumnType("int");

                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int?>("grade")
                        .HasColumnType("int");

                    b.HasKey("St_Id", "Crs_Id");

                    b.HasIndex("Crs_Id");

                    b.ToTable("Student_Courses");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Topic", b =>
                {
                    b.Property<int>("Top_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Top_Id"));

                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<string>("Topic_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Top_Id");

                    b.HasIndex("Crs_Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Choice", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("Qu_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Course", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("Ins_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Exam", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Course", "Course")
                        .WithMany("Exams")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Instructor", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Question", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Course", "Course")
                        .WithMany("Questions")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Student", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Student_Answer", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Exam", "Exam")
                        .WithMany("Student_Answers")
                        .HasForeignKey("Ex_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExamSystemEF.Models.Question", "Question")
                        .WithMany("Student_Answers")
                        .HasForeignKey("Qu_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExamSystemEF.Models.Student", "Student")
                        .WithMany("Student_Answers")
                        .HasForeignKey("St_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Student_Course", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Course", "Course")
                        .WithMany("Course_Students")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExamSystemEF.Models.Student", "Student")
                        .WithMany("Student_Courses")
                        .HasForeignKey("St_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Topic", b =>
                {
                    b.HasOne("ExamSystemEF.Models.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Course", b =>
                {
                    b.Navigation("Course_Students");

                    b.Navigation("Exams");

                    b.Navigation("Questions");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Department", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Exam", b =>
                {
                    b.Navigation("Student_Answers");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Instructor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Question", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("Student_Answers");
                });

            modelBuilder.Entity("ExamSystemEF.Models.Student", b =>
                {
                    b.Navigation("Student_Answers");

                    b.Navigation("Student_Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
