using Microsoft.EntityFrameworkCore.Migrations;

namespace graduationtourwebsite.Migrations
{
    public partial class place : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_places_tours_tId",
                table: "places");

            migrationBuilder.RenameColumn(
                name: "tId",
                table: "places",
                newName: "tourId");

            migrationBuilder.RenameColumn(
                name: "pics",
                table: "places",
                newName: "moreinfoURL");

            migrationBuilder.RenameColumn(
                name: "loc",
                table: "places",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_places_tId",
                table: "places",
                newName: "IX_places_tourId");

            migrationBuilder.AddColumn<string>(
                name: "aboutplace",
                table: "places",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_places_tours_tourId",
                table: "places",
                column: "tourId",
                principalTable: "tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_places_tours_tourId",
                table: "places");

            migrationBuilder.DropColumn(
                name: "aboutplace",
                table: "places");

            migrationBuilder.RenameColumn(
                name: "tourId",
                table: "places",
                newName: "tId");

            migrationBuilder.RenameColumn(
                name: "moreinfoURL",
                table: "places",
                newName: "pics");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "places",
                newName: "loc");

            migrationBuilder.RenameIndex(
                name: "IX_places_tourId",
                table: "places",
                newName: "IX_places_tId");

            migrationBuilder.AddForeignKey(
                name: "FK_places_tours_tId",
                table: "places",
                column: "tId",
                principalTable: "tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
