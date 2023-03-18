using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystemEF.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_Crs_Id",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Answers_Exams_Ex_Id",
                table: "Student_Answers");

            migrationBuilder.DropIndex(
                name: "IX_Student_Answers_Ex_Id",
                table: "Student_Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_Crs_Id",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Qu_Mark",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Crs_Id",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "Ex_FullMark",
                table: "Exams",
                newName: "Qu_Id");

            migrationBuilder.AddColumn<int>(
                name: "Ex_Id",
                table: "Student_Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qu_Id",
                table: "Student_Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionQu_Id",
                table: "Student_Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "St_Grade",
                table: "Student_Answers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ex_Id",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CourseCrs_Id",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                columns: new[] { "Ex_Id", "Qu_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Courses_Ex_Id_Qu_Id",
                table: "Student_Courses",
                columns: new[] { "Ex_Id", "Qu_Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Courses_QuestionQu_Id",
                table: "Student_Courses",
                column: "QuestionQu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Answers_Ex_Id_Qu_Id",
                table: "Student_Answers",
                columns: new[] { "Ex_Id", "Qu_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseCrs_Id",
                table: "Exams",
                column: "CourseCrs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Qu_Id",
                table: "Exams",
                column: "Qu_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseCrs_Id",
                table: "Exams",
                column: "CourseCrs_Id",
                principalTable: "Courses",
                principalColumn: "Crs_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Questions_Qu_Id",
                table: "Exams",
                column: "Qu_Id",
                principalTable: "Questions",
                principalColumn: "Qu_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Answers_Exams_Ex_Id_Qu_Id",
                table: "Student_Answers",
                columns: new[] { "Ex_Id", "Qu_Id" },
                principalTable: "Exams",
                principalColumns: new[] { "Ex_Id", "Qu_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Exams_Ex_Id_Qu_Id",
                table: "Student_Courses",
                columns: new[] { "Ex_Id", "Qu_Id" },
                principalTable: "Exams",
                principalColumns: new[] { "Ex_Id", "Qu_Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Questions_QuestionQu_Id",
                table: "Student_Courses",
                column: "QuestionQu_Id",
                principalTable: "Questions",
                principalColumn: "Qu_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseCrs_Id",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Questions_Qu_Id",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Answers_Exams_Ex_Id_Qu_Id",
                table: "Student_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Exams_Ex_Id_Qu_Id",
                table: "Student_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Questions_QuestionQu_Id",
                table: "Student_Courses");

            migrationBuilder.DropIndex(
                name: "IX_Student_Courses_Ex_Id_Qu_Id",
                table: "Student_Courses");

            migrationBuilder.DropIndex(
                name: "IX_Student_Courses_QuestionQu_Id",
                table: "Student_Courses");

            migrationBuilder.DropIndex(
                name: "IX_Student_Answers_Ex_Id_Qu_Id",
                table: "Student_Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CourseCrs_Id",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_Qu_Id",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Ex_Id",
                table: "Student_Courses");

            migrationBuilder.DropColumn(
                name: "Qu_Id",
                table: "Student_Courses");

            migrationBuilder.DropColumn(
                name: "QuestionQu_Id",
                table: "Student_Courses");

            migrationBuilder.DropColumn(
                name: "St_Grade",
                table: "Student_Answers");

            migrationBuilder.DropColumn(
                name: "CourseCrs_Id",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "Qu_Id",
                table: "Exams",
                newName: "Ex_FullMark");

            migrationBuilder.AddColumn<int>(
                name: "Qu_Mark",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Ex_Id",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Crs_Id",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Ex_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Answers_Ex_Id",
                table: "Student_Answers",
                column: "Ex_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Crs_Id",
                table: "Exams",
                column: "Crs_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_Crs_Id",
                table: "Exams",
                column: "Crs_Id",
                principalTable: "Courses",
                principalColumn: "Crs_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Answers_Exams_Ex_Id",
                table: "Student_Answers",
                column: "Ex_Id",
                principalTable: "Exams",
                principalColumn: "Ex_Id");
        }
    }
}
