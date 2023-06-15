﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Data.Migrations
{
    public partial class M23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_IdImage",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Publishers_IdProducer",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdImage",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdProduct",
                table: "Images",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_IdProduct",
                table: "Images",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_IdProducer",
                table: "Products",
                column: "IdProducer",
                principalTable: "Producers",
                principalColumn: "IdProducer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_IdProduct",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_IdProducer",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Images_IdProduct",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "IdImage",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Images",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdImage",
                table: "Products",
                column: "IdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_IdImage",
                table: "Products",
                column: "IdImage",
                principalTable: "Images",
                principalColumn: "IdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Publishers_IdProducer",
                table: "Products",
                column: "IdProducer",
                principalTable: "Publishers",
                principalColumn: "IdPublisher");
        }
    }
}
