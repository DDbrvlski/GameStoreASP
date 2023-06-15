using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "PageContent");

            migrationBuilder.DropColumn(
                name: "TitleLink",
                table: "PageContent");

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "PageContent",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PageContent",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdPage",
                table: "PageContent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "PageContent",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PageIdPage",
                table: "PageContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TitleLink",
                table: "Page",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageContent_Page_PageIdPage",
                table: "PageContent");

            migrationBuilder.DropIndex(
                name: "IX_PageContent_PageIdPage",
                table: "PageContent");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PageContent");

            migrationBuilder.DropColumn(
                name: "IdPage",
                table: "PageContent");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "PageContent");

            migrationBuilder.DropColumn(
                name: "PageIdPage",
                table: "PageContent");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "PageContent",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PageContent",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleLink",
                table: "PageContent",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TitleLink",
                table: "Page",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
