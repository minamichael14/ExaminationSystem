using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Migrations
{
    /// <inheritdoc />
    public partial class Course_question_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CourseID",
                table: "Questions",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseID",
                table: "Questions",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CourseID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Questions");
        }
    }
}
