using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_IdProduct",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_IdProduct",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "IdImage",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdImage",
                table: "Products",
                column: "IdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_IdImage",
                table: "Products",
                column: "IdImage",
                principalTable: "Images",
                principalColumn: "IdImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_IdImage",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdImage",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdProduct",
                table: "Images",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_IdProduct",
                table: "Images",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct");
        }
    }
}
