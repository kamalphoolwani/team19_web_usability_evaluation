using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSSD.Api.Admin.Migrations
{
    public partial class propertychange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Feedback");
        }
    }
}
