using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Accounts_IdAccount",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Products_IdProduct",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_IdProduct",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Rates");

            migrationBuilder.RenameColumn(
                name: "IdAccount",
                table: "Rates",
                newName: "ProductsIdProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_IdAccount",
                table: "Rates",
                newName: "IX_Rates_ProductsIdProduct");

            migrationBuilder.AddColumn<int>(
                name: "AccountsIdAccount",
                table: "Rates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Rates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RatesProductsAccounts",
                columns: table => new
                {
                    IdRatesProductsAccounts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccount = table.Column<int>(type: "int", nullable: true),
                    IdRate = table.Column<int>(type: "int", nullable: true),
                    IdProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatesProductsAccounts", x => x.IdRatesProductsAccounts);
                    table.ForeignKey(
                        name: "FK_RatesProductsAccounts_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount");
                    table.ForeignKey(
                        name: "FK_RatesProductsAccounts_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct");
                    table.ForeignKey(
                        name: "FK_RatesProductsAccounts_Rates_IdRate",
                        column: x => x.IdRate,
                        principalTable: "Rates",
                        principalColumn: "IdRate");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_AccountsIdAccount",
                table: "Rates",
                column: "AccountsIdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_RatesProductsAccounts_IdAccount",
                table: "RatesProductsAccounts",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_RatesProductsAccounts_IdProduct",
                table: "RatesProductsAccounts",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_RatesProductsAccounts_IdRate",
                table: "RatesProductsAccounts",
                column: "IdRate");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Accounts_AccountsIdAccount",
                table: "Rates",
                column: "AccountsIdAccount",
                principalTable: "Accounts",
                principalColumn: "IdAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Products_ProductsIdProduct",
                table: "Rates",
                column: "ProductsIdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Accounts_AccountsIdAccount",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Products_ProductsIdProduct",
                table: "Rates");

            migrationBuilder.DropTable(
                name: "RatesProductsAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Rates_AccountsIdAccount",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "AccountsIdAccount",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Rates");

            migrationBuilder.RenameColumn(
                name: "ProductsIdProduct",
                table: "Rates",
                newName: "IdAccount");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_ProductsIdProduct",
                table: "Rates",
                newName: "IX_Rates_IdAccount");

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_IdProduct",
                table: "Rates",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Accounts_IdAccount",
                table: "Rates",
                column: "IdAccount",
                principalTable: "Accounts",
                principalColumn: "IdAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Products_IdProduct",
                table: "Rates",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
