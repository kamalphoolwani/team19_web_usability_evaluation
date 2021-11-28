using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSSD.Api.Admin.Migrations
{
    public partial class initialmigrtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "testPortals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestPortalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StakeHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StakeHolderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testPortals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "testPortals");
        }
    }
}
