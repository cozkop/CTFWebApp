using Microsoft.EntityFrameworkCore.Migrations;

namespace CTFWebApp.Data.Migrations
{
    public partial class RemoveSubmittedAnswerField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittedAnswer",
                table: "Problem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubmittedAnswer",
                table: "Problem",
                nullable: true);
        }
    }
}
