using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystemEF.Migrations
{
    /// <inheritdoc />
    public partial class secondUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_Ex_Id",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Ex_Id",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Ex_Id",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ex_Id",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Ex_Id",
                table: "Questions",
                column: "Ex_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_Ex_Id",
                table: "Questions",
                column: "Ex_Id",
                principalTable: "Exams",
                principalColumn: "Ex_Id");
        }
    }
}
