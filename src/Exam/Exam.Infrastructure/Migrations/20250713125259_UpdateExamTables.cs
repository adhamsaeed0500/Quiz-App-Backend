using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExamTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puriod",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "choiceD",
                table: "Questions",
                newName: "answerD");

            migrationBuilder.RenameColumn(
                name: "choiceC",
                table: "Questions",
                newName: "answerC");

            migrationBuilder.RenameColumn(
                name: "choiceB",
                table: "Questions",
                newName: "answerB");

            migrationBuilder.RenameColumn(
                name: "choiceA",
                table: "Questions",
                newName: "answerA");

            migrationBuilder.AlterColumn<string>(
                name: "IsCorrect",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "answerD",
                table: "Questions",
                newName: "choiceD");

            migrationBuilder.RenameColumn(
                name: "answerC",
                table: "Questions",
                newName: "choiceC");

            migrationBuilder.RenameColumn(
                name: "answerB",
                table: "Questions",
                newName: "choiceB");

            migrationBuilder.RenameColumn(
                name: "answerA",
                table: "Questions",
                newName: "choiceA");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCorrect",
                table: "Questions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Puriod",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
