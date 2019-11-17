using Microsoft.EntityFrameworkCore.Migrations;

namespace CTFWebApp.Data.Migrations
{
    public partial class TeamCompletedProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamCompletedProblem",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    ProblemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCompletedProblem", x => new { x.TeamId, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_TeamCompletedProblem_Problem_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCompletedProblem_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamCompletedProblem_ProblemId",
                table: "TeamCompletedProblem",
                column: "ProblemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamCompletedProblem");
        }
    }
}
