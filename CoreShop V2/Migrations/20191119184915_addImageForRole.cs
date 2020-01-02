using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreShop_V2.Migrations
{
    public partial class addImageForRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetRoles");
        }
    }
}
