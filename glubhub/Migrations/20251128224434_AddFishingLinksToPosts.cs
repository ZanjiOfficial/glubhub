using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace glubhub.Migrations
{
    /// <inheritdoc />
    public partial class AddFishingLinksToPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FishId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GearId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechniqueId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipsId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FishId",
                table: "Posts",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GearId",
                table: "Posts",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PictureId",
                table: "Posts",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TechniqueId",
                table: "Posts",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TipsId",
                table: "Posts",
                column: "TipsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Fish_FishId",
                table: "Posts",
                column: "FishId",
                principalTable: "Fish",
                principalColumn: "FishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Gear_GearId",
                table: "Posts",
                column: "GearId",
                principalTable: "Gear",
                principalColumn: "GearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Pictures_PictureId",
                table: "Posts",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Techniques_TechniqueId",
                table: "Posts",
                column: "TechniqueId",
                principalTable: "Techniques",
                principalColumn: "TechniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tips_TipsId",
                table: "Posts",
                column: "TipsId",
                principalTable: "Tips",
                principalColumn: "TipsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Fish_FishId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Gear_GearId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Pictures_PictureId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Techniques_TechniqueId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tips_TipsId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_FishId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GearId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PictureId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TechniqueId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TipsId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FishId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "GearId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TechniqueId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TipsId",
                table: "Posts");
        }
    }
}
