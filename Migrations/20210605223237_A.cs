using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesProgect.Migrations
{
    public partial class A : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingTrainDate",
                table: "heros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartingTrainDate",
                table: "heros",
                type: "datetime2",
                nullable: true);
        }
    }
}
