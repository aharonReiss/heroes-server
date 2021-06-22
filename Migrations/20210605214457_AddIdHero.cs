using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesProgect.Migrations
{
    public partial class AddIdHero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "heros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "heros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
