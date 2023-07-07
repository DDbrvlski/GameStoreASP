using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "OrderElement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderElement_IdProduct",
                table: "OrderElement",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderElement_Products_IdProduct",
                table: "OrderElement",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderElement_Products_IdProduct",
                table: "OrderElement");

            migrationBuilder.DropIndex(
                name: "IX_OrderElement_IdProduct",
                table: "OrderElement");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "OrderElement");
        }
    }
}
