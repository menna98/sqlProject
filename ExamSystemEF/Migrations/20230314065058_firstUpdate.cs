using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystemEF.Migrations
{
    /// <inheritdoc />
    public partial class firstUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "St_Age",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Ex_FullMark",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ex_FullMark",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "St_Age",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
