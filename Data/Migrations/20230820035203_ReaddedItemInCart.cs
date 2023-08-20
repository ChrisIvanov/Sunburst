using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunburst.Data.Migrations
{
    public partial class ReaddedItemInCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemInCart")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
    name: "ItemsInCarts",
    columns: table => new
    {
        Id = table.Column<int>(type: "int", nullable: false),
        CartId = table.Column<int>(type: "int", nullable: false),
        ItemId = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
    });

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemsInCarts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsInCarts",
                table: "ItemsInCarts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
