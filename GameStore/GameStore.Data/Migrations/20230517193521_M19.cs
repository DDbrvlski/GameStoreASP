using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountType_AccountTypeId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Accounts_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Accounts_Id",
                table: "Rates");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Rates_Id",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Comments_Id",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Rates",
                newName: "IdAccount");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "IdOrder");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Comments",
                newName: "IdAccount");

            migrationBuilder.AddColumn<int>(
                name: "IdPlatform",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPublisher",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTypesOfProducts",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAccountType",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypesOfProducts",
                columns: table => new
                {
                    IdTypesOfProducts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfProducts", x => x.IdTypesOfProducts);
                    table.ForeignKey(
                        name: "FK_TypesOfProducts_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_IdAccount",
                table: "Rates",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdPlatform",
                table: "Products",
                column: "IdPlatform");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdPublisher",
                table: "Products",
                column: "IdPublisher");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdTypesOfProducts",
                table: "Products",
                column: "IdTypesOfProducts");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdAccount",
                table: "Comments",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdAccountType",
                table: "Accounts",
                column: "IdAccountType");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfProducts_IdCategory",
                table: "TypesOfProducts",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountType_IdAccountType",
                table: "Accounts",
                column: "IdAccountType",
                principalTable: "AccountType",
                principalColumn: "IdAccountType");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Accounts_IdAccount",
                table: "Comments",
                column: "IdAccount",
                principalTable: "Accounts",
                principalColumn: "IdAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Platforms_IdPlatform",
                table: "Products",
                column: "IdPlatform",
                principalTable: "Platforms",
                principalColumn: "IdPlatform");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Publishers_IdPublisher",
                table: "Products",
                column: "IdPublisher",
                principalTable: "Publishers",
                principalColumn: "IdPublisher");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypesOfProducts_IdTypesOfProducts",
                table: "Products",
                column: "IdTypesOfProducts",
                principalTable: "TypesOfProducts",
                principalColumn: "IdTypesOfProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Accounts_IdAccount",
                table: "Rates",
                column: "IdAccount",
                principalTable: "Accounts",
                principalColumn: "IdAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountType_IdAccountType",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Accounts_IdAccount",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Platforms_IdPlatform",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Publishers_IdPublisher",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypesOfProducts_IdTypesOfProducts",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Accounts_IdAccount",
                table: "Rates");

            migrationBuilder.DropTable(
                name: "TypesOfProducts");

            migrationBuilder.DropIndex(
                name: "IX_Rates_IdAccount",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdPlatform",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdPublisher",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdTypesOfProducts",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IdAccount",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_IdAccountType",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IdPlatform",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdPublisher",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdTypesOfProducts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdAccountType",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "IdAccount",
                table: "Rates",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "IdOrder",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "IdAccount",
                table: "Comments",
                newName: "IdUser");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    IdType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.IdType);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_Id",
                table: "Rates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Id",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountType_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId",
                principalTable: "AccountType",
                principalColumn: "IdAccountType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Accounts_Id",
                table: "Comments",
                column: "Id",
                principalTable: "Accounts",
                principalColumn: "IdAccount",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Accounts_Id",
                table: "Rates",
                column: "Id",
                principalTable: "Accounts",
                principalColumn: "IdAccount",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
