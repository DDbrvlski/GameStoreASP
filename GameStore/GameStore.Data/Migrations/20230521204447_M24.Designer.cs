﻿// <auto-generated />
using System;
using GameStore.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameStore.Data.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    [Migration("20230521204447_M24")]
    partial class M24
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameStore.Data.Data.Account.Accounts", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccount"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("IdAccountType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAccount");

                    b.HasIndex("IdAccountType");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("GameStore.Data.Data.Account.AccountType", b =>
                {
                    b.Property<int>("IdAccountType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccountType"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAccountType");

                    b.ToTable("AccountType");
                });

            modelBuilder.Entity("GameStore.Data.Data.Account.OrderHistory", b =>
                {
                    b.Property<int>("IdOrderHistory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrderHistory"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("IdOrderHistory");

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("GameStore.Data.Data.Account.Orders", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrder"), 1L, 1);

                    b.Property<int?>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int?>("IdOrderHistory")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdOrder");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdOrderHistory");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GameStore.Data.Data.CMS.FooterDetails", b =>
                {
                    b.Property<int>("IdFooterDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFooterDetail"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("IdFooterDetail");

                    b.ToTable("FooterDetails");
                });

            modelBuilder.Entity("GameStore.Data.Data.CMS.FooterLinks", b =>
                {
                    b.Property<int>("IdFooterLink")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFooterLink"), 1L, 1);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("IdFooterLink");

                    b.ToTable("FooterLinks");
                });

            modelBuilder.Entity("GameStore.Data.Data.CMS.News", b =>
                {
                    b.Property<int>("IdNews")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNews"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TitleLink")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdNews");

                    b.ToTable("News");
                });

            modelBuilder.Entity("GameStore.Data.Data.CMS.Page", b =>
                {
                    b.Property<int>("IdPage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPage"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TitleLink")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdPage");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("GameStore.Data.Data.CMS.PageContent", b =>
                {
                    b.Property<int>("IdPageContent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPageContent"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int?>("IdPage")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("IdPageContent");

                    b.HasIndex("IdPage");

                    b.ToTable("PageContent");
                });

            modelBuilder.Entity("GameStore.Data.Data.Media.Images", b =>
                {
                    b.Property<int>("IdImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImage"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.HasKey("IdImage");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Categories", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("IdCategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Comments", b =>
                {
                    b.Property<int>("IdComment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComment"), 1L, 1);

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdComment");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdProduct");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Platforms", b =>
                {
                    b.Property<int>("IdPlatform")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlatform"), 1L, 1);

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPlatform");

                    b.HasIndex("IdCategory");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Producers", b =>
                {
                    b.Property<int>("IdProducer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducer"), 1L, 1);

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProducer");

                    b.HasIndex("IdCategory");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Products", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int?>("IdImage")
                        .HasColumnType("int");

                    b.Property<int?>("IdPlatform")
                        .HasColumnType("int");

                    b.Property<int?>("IdProducer")
                        .HasColumnType("int");

                    b.Property<int?>("IdPublisher")
                        .HasColumnType("int");

                    b.Property<int?>("IdTypesOfProducts")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("IdProduct");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdImage");

                    b.HasIndex("IdPlatform");

                    b.HasIndex("IdProducer");

                    b.HasIndex("IdPublisher");

                    b.HasIndex("IdTypesOfProducts");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Publishers", b =>
                {
                    b.Property<int>("IdPublisher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublisher"), 1L, 1);

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPublisher");

                    b.HasIndex("IdCategory");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Rates", b =>
                {
                    b.Property<int>("IdRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRate"), 1L, 1);

                    b.Property<int?>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("IdRate");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdProduct");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.TypesOfProducts", b =>
                {
                    b.Property<int>("IdTypesOfProducts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypesOfProducts"), 1L, 1);

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypesOfProducts");

                    b.HasIndex("IdCategory");

                    b.ToTable("TypesOfProducts");
                });

            modelBuilder.Entity("GameStore.Data.Data.Account.Accounts", b =>
                {
                    b.HasOne("GameStore.Data.Data.Account.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("IdAccountType");

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("GameStore.Data.Data.Account.Orders", b =>
                {
                    b.HasOne("GameStore.Data.Data.Account.Accounts", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("IdAccount");

                    b.HasOne("GameStore.Data.Data.Account.OrderHistory", "OrderHistory")
                        .WithMany("Orders")
                        .HasForeignKey("IdOrderHistory");

                    b.Navigation("Account");

                    b.Navigation("OrderHistory");
                });

            modelBuilder.Entity("GameStore.Data.Data.CMS.PageContent", b =>
                {
                    b.HasOne("GameStore.Data.Data.CMS.Page", "Page")
                        .WithMany()
                        .HasForeignKey("IdPage");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Comments", b =>
                {
                    b.HasOne("GameStore.Data.Data.Account.Accounts", "Account")
                        .WithMany("Comments")
                        .HasForeignKey("IdAccount");

                    b.HasOne("GameStore.Data.Data.Shop.Products", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("IdProduct");

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Platforms", b =>
                {
                    b.HasOne("GameStore.Data.Data.Shop.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Producers", b =>
                {
                    b.HasOne("GameStore.Data.Data.Shop.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Products", b =>
                {
                    b.HasOne("GameStore.Data.Data.Shop.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory");

                    b.HasOne("GameStore.Data.Data.Media.Images", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage");

                    b.HasOne("GameStore.Data.Data.Shop.Platforms", "Platform")
                        .WithMany()
                        .HasForeignKey("IdPlatform");

                    b.HasOne("GameStore.Data.Data.Shop.Producers", "Producer")
                        .WithMany()
                        .HasForeignKey("IdProducer");

                    b.HasOne("GameStore.Data.Data.Shop.Publishers", "Publisher")
                        .WithMany()
                        .HasForeignKey("IdPublisher");

                    b.HasOne("GameStore.Data.Data.Shop.TypesOfProducts", "TypeOfProduct")
                        .WithMany()
                        .HasForeignKey("IdTypesOfProducts");

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("Platform");

                    b.Navigation("Producer");

                    b.Navigation("Publisher");

                    b.Navigation("TypeOfProduct");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Publishers", b =>
                {
                    b.HasOne("GameStore.Data.Data.Shop.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Rates", b =>
                {
                    b.HasOne("GameStore.Data.Data.Account.Accounts", "Account")
                        .WithMany("Rates")
                        .HasForeignKey("IdAccount");

                    b.HasOne("GameStore.Data.Data.Shop.Products", "Product")
                        .WithMany("Rates")
                        .HasForeignKey("IdProduct");

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.TypesOfProducts", b =>
                {
                    b.HasOne("GameStore.Data.Data.Shop.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GameStore.Data.Data.Account.Accounts", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Orders");

                    b.Navigation("Rates");
                });

            modelBuilder.Entity("GameStore.Data.Data.Account.OrderHistory", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GameStore.Data.Data.Shop.Products", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
