using Microsoft.EntityFrameworkCore.Migrations;

namespace EGrocery1.Migrations
{
    public partial class addCustomerDetailsToDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rpassword",
                table: "CustomerDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rpassword",
                table: "CustomerDetails");
        }
    }
}
