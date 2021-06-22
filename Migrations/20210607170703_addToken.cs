using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesProgect.Migrations
{
    public partial class addToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token",
                table: "users");
        }
    }
}
