using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateIndex(
                name: "IX_PageContent_IdPage",
                table: "PageContent",
                column: "IdPage");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageContent_Page_IdPage",
                table: "PageContent");

            migrationBuilder.DropIndex(
                name: "IX_PageContent_IdPage",
                table: "PageContent");

            migrationBuilder.AddColumn<int>(
                name: "PageIdPage",
                table: "PageContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PageContent_PageIdPage",
                table: "PageContent",
                column: "PageIdPage");

            migrationBuilder.AddForeignKey(
                name: "FK_PageContent_Page_PageIdPage",
                table: "PageContent",
                column: "PageIdPage",
                principalTable: "Page",
                principalColumn: "IdPage",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
