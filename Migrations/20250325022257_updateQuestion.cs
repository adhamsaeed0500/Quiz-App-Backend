using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz_App.Migrations
{
    /// <inheritdoc />
    public partial class updateQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "choiceA",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "choiceB",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "choiceC",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "choiceD",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "choiceA",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "choiceB",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "choiceC",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "choiceD",
                table: "Questions");
        }
    }
}
