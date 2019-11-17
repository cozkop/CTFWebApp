using Microsoft.EntityFrameworkCore.Migrations;

namespace CTFWebApp.Data.Migrations
{
    public partial class AddCaptianUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "captain",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "captain",
                table: "AspNetUsers");
        }
    }
}
