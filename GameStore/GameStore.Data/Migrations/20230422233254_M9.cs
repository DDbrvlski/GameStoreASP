using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryIdCategory",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_ImageIdImage",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryIdCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImageIdImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryIdCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageIdImage",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "IdCategory",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdImage",
                table: "Products",
                column: "IdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory");

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
                name: "FK_Products_Categories_IdCategory",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_IdImage",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdImage",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "IdCategory",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryIdCategory",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageIdImage",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryIdCategory",
                table: "Products",
                column: "CategoryIdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageIdImage",
                table: "Products",
                column: "ImageIdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryIdCategory",
                table: "Products",
                column: "CategoryIdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_ImageIdImage",
                table: "Products",
                column: "ImageIdImage",
                principalTable: "Images",
                principalColumn: "IdImage",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
