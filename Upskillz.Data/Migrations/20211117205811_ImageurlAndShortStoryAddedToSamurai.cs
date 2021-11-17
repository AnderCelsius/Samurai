using Microsoft.EntityFrameworkCore.Migrations;

namespace Upskillz.Data.Migrations
{
    public partial class ImageurlAndShortStoryAddedToSamurai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Samurais",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Samurais",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortStory",
                table: "Samurais",
                type: "character varying(1020)",
                maxLength: 1020,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "ShortStory",
                table: "Samurais");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Samurais",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
