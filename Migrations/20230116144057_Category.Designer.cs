﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeathernyCocktails.Data;

#nullable disable

namespace SeathernyCocktails.Migrations
{
    [DbContext(typeof(SeathernyCocktailsContext))]
    [Migration("20230116144057_Category")]
    partial class Category
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeathernyCocktails.Models.Bartender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Bartender");
                });

            modelBuilder.Entity("SeathernyCocktails.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SeathernyCocktails.Models.Cocktail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BartenderID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("BartenderID");

                    b.ToTable("Cocktail");
                });

            modelBuilder.Entity("SeathernyCocktails.Models.CocktailCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("CocktailID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CocktailID");

                    b.ToTable("CocktailCategory");
                });

            modelBuilder.Entity("SeathernyCocktails.Models.Cocktail", b =>
                {
                    b.HasOne("SeathernyCocktails.Models.Bartender", "Bartender")
                        .WithMany("Cocktails")
                        .HasForeignKey("BartenderID");

                    b.Navigation("Bartender");
                });

            modelBuilder.Entity("SeathernyCocktails.Models.CocktailCategory", b =>
                {
                    b.HasOne("SeathernyCocktails.Models.Category", "Category")
                        .WithMany("CocktailCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeathernyCocktails.Models.Cocktail", "Cocktail")
                        .WithMany("CocktailCategories")
                        .HasForeignKey("CocktailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Cocktail");
                });

            modelBuilder.Entity("SeathernyCocktails.Models.Bartender", b =>
                {
                    b.Navigation("Cocktails");
                });

            modelBuilder.Entity("SeathernyCocktails.Models.Category", b =>
                {
                    b.Navigation("CocktailCategories");
                });

            modelBuilder.Entity("SeathernyCocktails.Models.Cocktail", b =>
                {
                    b.Navigation("CocktailCategories");
                });
#pragma warning restore 612, 618
        }
    }
}