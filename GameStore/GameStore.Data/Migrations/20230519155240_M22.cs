using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Publishers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Producers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Platforms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_IdCategory",
                table: "Publishers",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Producers_IdCategory",
                table: "Producers",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_IdCategory",
                table: "Platforms",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Categories_IdCategory",
                table: "Platforms",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Producers_Categories_IdCategory",
                table: "Producers",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Categories_IdCategory",
                table: "Publishers",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Categories_IdCategory",
                table: "Platforms");

            migrationBuilder.DropForeignKey(
                name: "FK_Producers_Categories_IdCategory",
                table: "Producers");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Categories_IdCategory",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_IdCategory",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Producers_IdCategory",
                table: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_IdCategory",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Platforms");
        }
    }
}
