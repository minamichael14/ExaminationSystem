using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Migrations
{
    /// <inheritdoc />
    public partial class editSubmittedAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswer_ExamQuestion_ExamQuestionID",
                table: "SubmittedAnswer");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedAnswer_ExamQuestionID",
                table: "SubmittedAnswer");

            migrationBuilder.RenameColumn(
                name: "ExamQuestionID",
                table: "SubmittedAnswer",
                newName: "QuestionID");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Result",
                newName: "Value");

            migrationBuilder.AddColumn<int>(
                name: "ExamID",
                table: "SubmittedAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamID",
                table: "SubmittedAnswer");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "SubmittedAnswer",
                newName: "ExamQuestionID");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Result",
                newName: "value");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswer_ExamQuestionID",
                table: "SubmittedAnswer",
                column: "ExamQuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswer_ExamQuestion_ExamQuestionID",
                table: "SubmittedAnswer",
                column: "ExamQuestionID",
                principalTable: "ExamQuestion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
