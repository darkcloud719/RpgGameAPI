using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgGameApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    SeqId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateData = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteUser = table.Column<string>(maxLength: 100, nullable: true),
                    DeleteFlag = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    HitPoints = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    RpgClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.SeqId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
