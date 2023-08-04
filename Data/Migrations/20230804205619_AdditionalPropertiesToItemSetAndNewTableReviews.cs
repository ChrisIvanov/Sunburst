using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunburst.Data.Migrations
{
    public partial class AdditionalPropertiesToItemSetAndNewTableReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Hitories");

            migrationBuilder.RenameColumn(
                name: "IsSet",
                table: "Items",
                newName: "HasSet");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverallRating",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hitories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Carts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Edited",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ReviewDescr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewRating = table.Column<int>(type: "int", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Hitories_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Hitories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_HistoryId",
                table: "Items",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_HistoryId",
                table: "Carts",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_HistoryId",
                table: "Review",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Hitories_HistoryId",
                table: "Carts",
                column: "HistoryId",
                principalTable: "Hitories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Hitories_HistoryId",
                table: "Items",
                column: "HistoryId",
                principalTable: "Hitories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Hitories_HistoryId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Hitories_HistoryId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Items_HistoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Carts_HistoryId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hitories");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Edited",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "HasSet",
                table: "Items",
                newName: "IsSet");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Hitories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
