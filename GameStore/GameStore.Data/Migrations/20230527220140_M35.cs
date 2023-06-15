using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Accounts_IdAccount",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_IdProduct",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IdAccount",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IdProduct",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IdAccount",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "IdComment",
                table: "RatesProductsAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RatesProductsAccounts_IdComment",
                table: "RatesProductsAccounts",
                column: "IdComment");

            migrationBuilder.AddForeignKey(
                name: "FK_RatesProductsAccounts_Comments_IdComment",
                table: "RatesProductsAccounts",
                column: "IdComment",
                principalTable: "Comments",
                principalColumn: "IdComment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatesProductsAccounts_Comments_IdComment",
                table: "RatesProductsAccounts");

            migrationBuilder.DropIndex(
                name: "IX_RatesProductsAccounts_IdComment",
                table: "RatesProductsAccounts");

            migrationBuilder.DropColumn(
                name: "IdComment",
                table: "RatesProductsAccounts");

            migrationBuilder.AddColumn<int>(
                name: "IdAccount",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdAccount",
                table: "Comments",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdProduct",
                table: "Comments",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Accounts_IdAccount",
                table: "Comments",
                column: "IdAccount",
                principalTable: "Accounts",
                principalColumn: "IdAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_IdProduct",
                table: "Comments",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
