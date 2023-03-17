using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystemEF.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dept_Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Ins_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ins_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ins_Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Ins_Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "Departments",
                        principalColumn: "Dept_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    St_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    St_Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    St_Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    St_DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    St_Age = table.Column<int>(type: "int", nullable: false),
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.St_Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "Departments",
                        principalColumn: "Dept_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Crs_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crs_Name = table.Column<int>(type: "int", nullable: false),
                    EvaluationPercent = table.Column<int>(type: "int", nullable: false),
                    Ins_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Crs_Id);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_Ins_Id",
                        column: x => x.Ins_Id,
                        principalTable: "Instructors",
                        principalColumn: "Ins_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Ex_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crs_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Ex_Id);
                    table.ForeignKey(
                        name: "FK_Exams_Courses_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Courses",
                        principalColumn: "Crs_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Courses",
                columns: table => new
                {
                    St_Id = table.Column<int>(type: "int", nullable: false),
                    Crs_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Courses", x => new { x.St_Id, x.Crs_Id });
                    table.ForeignKey(
                        name: "FK_Student_Courses_Courses_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Courses",
                        principalColumn: "Crs_Id");
                    table.ForeignKey(
                        name: "FK_Student_Courses_Students_St_Id",
                        column: x => x.St_Id,
                        principalTable: "Students",
                        principalColumn: "St_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Top_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crs_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Top_Id);
                    table.ForeignKey(
                        name: "FK_Topics_Courses_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Courses",
                        principalColumn: "Crs_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Qu_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qu_Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qu_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qu_Mark = table.Column<int>(type: "int", nullable: false),
                    Qu_ModelAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crs_Id = table.Column<int>(type: "int", nullable: false),
                    Ex_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Qu_Id);
                    table.ForeignKey(
                        name: "FK_Questions_Courses_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Courses",
                        principalColumn: "Crs_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_Ex_Id",
                        column: x => x.Ex_Id,
                        principalTable: "Exams",
                        principalColumn: "Ex_Id");
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Qu_Choice = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qu_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => new { x.Qu_Id, x.Qu_Choice });
                    table.ForeignKey(
                        name: "FK_Choices_Questions_Qu_Id",
                        column: x => x.Qu_Id,
                        principalTable: "Questions",
                        principalColumn: "Qu_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Answers",
                columns: table => new
                {
                    St_Id = table.Column<int>(type: "int", nullable: false),
                    Ex_Id = table.Column<int>(type: "int", nullable: false),
                    Qu_Id = table.Column<int>(type: "int", nullable: false),
                    St_Ans = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Answers", x => new { x.St_Id, x.Ex_Id, x.Qu_Id });
                    table.ForeignKey(
                        name: "FK_Student_Answers_Exams_Ex_Id",
                        column: x => x.Ex_Id,
                        principalTable: "Exams",
                        principalColumn: "Ex_Id");
                    table.ForeignKey(
                        name: "FK_Student_Answers_Questions_Qu_Id",
                        column: x => x.Qu_Id,
                        principalTable: "Questions",
                        principalColumn: "Qu_Id");
                    table.ForeignKey(
                        name: "FK_Student_Answers_Students_St_Id",
                        column: x => x.St_Id,
                        principalTable: "Students",
                        principalColumn: "St_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Ins_Id",
                table: "Courses",
                column: "Ins_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Crs_Id",
                table: "Exams",
                column: "Crs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Dept_Id",
                table: "Instructors",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Crs_Id",
                table: "Questions",
                column: "Crs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Ex_Id",
                table: "Questions",
                column: "Ex_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Answers_Ex_Id",
                table: "Student_Answers",
                column: "Ex_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Answers_Qu_Id",
                table: "Student_Answers",
                column: "Qu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Courses_Crs_Id",
                table: "Student_Courses",
                column: "Crs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Dept_Id",
                table: "Students",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_Crs_Id",
                table: "Topics",
                column: "Crs_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Student_Answers");

            migrationBuilder.DropTable(
                name: "Student_Courses");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
