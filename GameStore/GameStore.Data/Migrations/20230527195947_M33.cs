using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Accounts_AccountsIdAccount",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_AccountsIdAccount",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "AccountsIdAccount",
                table: "Rates");

            migrationBuilder.AddColumn<int>(
                name: "IdRate",
                table: "RatesProductsAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RatesProductsAccounts_IdRate",
                table: "RatesProductsAccounts",
                column: "IdRate");

            migrationBuilder.AddForeignKey(
                name: "FK_RatesProductsAccounts_Rates_IdRate",
                table: "RatesProductsAccounts",
                column: "IdRate",
                principalTable: "Rates",
                principalColumn: "IdRate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatesProductsAccounts_Rates_IdRate",
                table: "RatesProductsAccounts");

            migrationBuilder.DropIndex(
                name: "IX_RatesProductsAccounts_IdRate",
                table: "RatesProductsAccounts");

            migrationBuilder.DropColumn(
                name: "IdRate",
                table: "RatesProductsAccounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountsIdAccount",
                table: "Rates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_AccountsIdAccount",
                table: "Rates",
                column: "AccountsIdAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Accounts_AccountsIdAccount",
                table: "Rates",
                column: "AccountsIdAccount",
                principalTable: "Accounts",
                principalColumn: "IdAccount");
        }
    }
}
