using Microsoft.EntityFrameworkCore.Migrations;

namespace graduationtourwebsite.Migrations
{
    public partial class tourupdate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "priceafter",
                table: "tours",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "status",
                table: "tours",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priceafter",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "status",
                table: "tours");
        }
    }
}
