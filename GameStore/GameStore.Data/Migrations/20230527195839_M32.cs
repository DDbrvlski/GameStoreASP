using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Products_ProductsIdProduct",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_RatesProductsAccounts_Rates_IdRate",
                table: "RatesProductsAccounts");

            migrationBuilder.DropIndex(
                name: "IX_RatesProductsAccounts_IdRate",
                table: "RatesProductsAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Rates_ProductsIdProduct",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "IdRate",
                table: "RatesProductsAccounts");

            migrationBuilder.DropColumn(
                name: "ProductsIdProduct",
                table: "Rates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRate",
                table: "RatesProductsAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsIdProduct",
                table: "Rates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RatesProductsAccounts_IdRate",
                table: "RatesProductsAccounts",
                column: "IdRate");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ProductsIdProduct",
                table: "Rates",
                column: "ProductsIdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Products_ProductsIdProduct",
                table: "Rates",
                column: "ProductsIdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_RatesProductsAccounts_Rates_IdRate",
                table: "RatesProductsAccounts",
                column: "IdRate",
                principalTable: "Rates",
                principalColumn: "IdRate");
        }
    }
}
