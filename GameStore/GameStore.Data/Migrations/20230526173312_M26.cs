using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
