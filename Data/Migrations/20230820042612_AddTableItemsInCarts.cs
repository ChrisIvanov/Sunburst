using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunburst.Data.Migrations
{
    public partial class AddTableItemsInCarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
    name: "ColumnName",
    table: "TableName");

            migrationBuilder.AddColumn<int>(
    name: "ColumnName",
    table: "TableName")
    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
