using Microsoft.EntityFrameworkCore.Migrations;

namespace EGrocery1.Migrations
{
    public partial class updateItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl2",
                table: "Items");
        }
    }
}
