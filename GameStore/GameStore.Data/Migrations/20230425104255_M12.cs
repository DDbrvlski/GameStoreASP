﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageContent",
                columns: table => new
                {
                    IdPageContent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IdPage = table.Column<int>(type: "int", nullable: true),
                    PageIdPage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageContent", x => x.IdPageContent);
                    table.ForeignKey(
                        name: "FK_PageContent_Page_PageIdPage",
                        column: x => x.PageIdPage,
                        principalTable: "Page",
                        principalColumn: "IdPage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageContent_PageIdPage",
                table: "PageContent",
                column: "PageIdPage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageContent");
        }
    }
}
