using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProducer",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProducer",
                table: "Products",
                column: "IdProducer");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Publishers_IdProducer",
                table: "Products",
                column: "IdProducer",
                principalTable: "Publishers",
                principalColumn: "IdPublisher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Publishers_IdProducer",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdProducer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdProducer",
                table: "Products");
        }
    }
}
