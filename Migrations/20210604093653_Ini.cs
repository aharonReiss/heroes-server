using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesProgect.Migrations
{
    public partial class Ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "heros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ability = table.Column<int>(type: "int", nullable: false),
                    GuidId = table.Column<int>(type: "int", nullable: false),
                    StartedTrain = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    SuitColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingPower = table.Column<int>(type: "int", nullable: false),
                    CurrentPower = table.Column<int>(type: "int", nullable: false),
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimesTrainToday = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_heros_users_GuidId",
                        column: x => x.GuidId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_heros_GuidId",
                table: "heros",
                column: "GuidId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "heros");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
