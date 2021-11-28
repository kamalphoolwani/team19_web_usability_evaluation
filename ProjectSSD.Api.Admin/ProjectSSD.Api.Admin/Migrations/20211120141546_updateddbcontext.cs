using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSSD.Api.Admin.Migrations
{
    public partial class updateddbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_testPortals",
                table: "testPortals");

            migrationBuilder.RenameTable(
                name: "testPortals",
                newName: "TestPortal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestPortal",
                table: "TestPortal",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    TestPortalId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestPortalId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestPortal",
                table: "TestPortal");

            migrationBuilder.RenameTable(
                name: "TestPortal",
                newName: "testPortals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_testPortals",
                table: "testPortals",
                column: "Id");
        }
    }
}
