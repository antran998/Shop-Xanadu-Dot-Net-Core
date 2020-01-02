using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreShop_V2.Migrations
{
    public partial class AddMoneySpended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MoneySpended",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneySpended",
                table: "AspNetUsers");
        }
    }
}
