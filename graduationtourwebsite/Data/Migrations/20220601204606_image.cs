using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace graduationtourwebsite.Data.Migrations
{
    public partial class image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "profilepicture",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilepicture",
                table: "Users");
        }
    }
}
