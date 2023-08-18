using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunburst.Data.Migrations
{
    public partial class UpdatedCartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Carts");
        }
    }
}
