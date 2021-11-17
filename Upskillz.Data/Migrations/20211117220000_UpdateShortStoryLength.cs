using Microsoft.EntityFrameworkCore.Migrations;

namespace Upskillz.Data.Migrations
{
    public partial class UpdateShortStoryLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortStory",
                table: "Samurais",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1020)",
                oldMaxLength: 1020,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortStory",
                table: "Samurais",
                type: "character varying(1020)",
                maxLength: 1020,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
