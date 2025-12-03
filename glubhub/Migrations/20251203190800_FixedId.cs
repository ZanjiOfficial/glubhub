using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace glubhub.Migrations
{
    /// <inheritdoc />
    public partial class FixedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Gear_GearId1",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Techniques_TechniqueId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GearId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TechniqueId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "GearId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TechniqueId1",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "TechniqueId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GearId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GearId",
                table: "Posts",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TechniqueId",
                table: "Posts",
                column: "TechniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Gear_GearId",
                table: "Posts",
                column: "GearId",
                principalTable: "Gear",
                principalColumn: "GearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Techniques_TechniqueId",
                table: "Posts",
                column: "TechniqueId",
                principalTable: "Techniques",
                principalColumn: "TechniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Gear_GearId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Techniques_TechniqueId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GearId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TechniqueId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "TechniqueId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GearId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GearId1",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechniqueId1",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GearId1",
                table: "Posts",
                column: "GearId1");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TechniqueId1",
                table: "Posts",
                column: "TechniqueId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Gear_GearId1",
                table: "Posts",
                column: "GearId1",
                principalTable: "Gear",
                principalColumn: "GearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Techniques_TechniqueId1",
                table: "Posts",
                column: "TechniqueId1",
                principalTable: "Techniques",
                principalColumn: "TechniqueId");
        }
    }
}
