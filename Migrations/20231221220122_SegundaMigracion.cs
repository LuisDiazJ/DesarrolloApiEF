using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesarrolloApiEF.Migrations
{
    public partial class SegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_animals_BreedId",
                table: "animals",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_breeds_BreedId",
                table: "animals",
                column: "BreedId",
                principalTable: "breeds",
                principalColumn: "BreedsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_breeds_BreedId",
                table: "animals");

            migrationBuilder.DropIndex(
                name: "IX_animals_BreedId",
                table: "animals");
        }
    }
}
