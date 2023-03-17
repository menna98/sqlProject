using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystemEF.Migrations
{
    /// <inheritdoc />
    public partial class gradeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "grade",
                table: "Student_Courses",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "grade",
                table: "Student_Courses");
        }
    }
}
