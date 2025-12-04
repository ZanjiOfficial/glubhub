using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace glubhub.Migrations
{
    /// <inheritdoc />
    public partial class AddTagColumnsToPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GearTags",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechniqueTags",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GearTags",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TechniqueTags",
                table: "Posts");
        }
    }
}
