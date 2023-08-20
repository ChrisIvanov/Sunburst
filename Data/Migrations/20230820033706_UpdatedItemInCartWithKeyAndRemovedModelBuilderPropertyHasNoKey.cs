using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunburst.Data.Migrations
{
    public partial class UpdatedItemInCartWithKeyAndRemovedModelBuilderPropertyHasNoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsInCarts",
                table: "ItemsInCarts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemsInCarts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
