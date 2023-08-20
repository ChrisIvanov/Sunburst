using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunburst.Data.Migrations
{
    public partial class RemovedItemInCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemInCart");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
