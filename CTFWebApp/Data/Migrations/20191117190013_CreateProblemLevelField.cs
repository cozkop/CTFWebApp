using Microsoft.EntityFrameworkCore.Migrations;

namespace CTFWebApp.Data.Migrations
{
    public partial class CreateProblemLevelField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProblemLevel",
                table: "Problem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemLevel",
                table: "Problem");
        }
    }
}
