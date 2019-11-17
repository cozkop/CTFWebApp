using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTFWebApp.Data.Migrations
{
    public partial class ProblemAndTeamTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyTeamId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Problem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProblemName = table.Column<string>(nullable: true),
                    ProblemDescription = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    SubmittedAnswer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: true),
                    TeamDescription = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MyTeamId",
                table: "AspNetUsers",
                column: "MyTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Team_MyTeamId",
                table: "AspNetUsers",
                column: "MyTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Team_MyTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Problem");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MyTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MyTeamId",
                table: "AspNetUsers");
        }
    }
}
