using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gradebook.Infrastructure.Migrations
{
    public partial class SomeChanges5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TutorName",
                table: "Groups",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TutorName",
                table: "Groups");
        }
    }
}
