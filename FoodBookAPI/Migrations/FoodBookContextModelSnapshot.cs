﻿// <auto-generated />
using System;
using FoodBookAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodBookAPI.Migrations
{
    [DbContext(typeof(FoodBookContext))]
    partial class FoodBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.CuisineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdImage")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.ToTable("CuisineType");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.Difficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.DishType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdImage")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.ToTable("DishType");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.Ingredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("AmountOfUnit")
                        .HasColumnType("real");

                    b.Property<float>("Carbs")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Fats")
                        .HasColumnType("real");

                    b.Property<int?>("IdUnitOfMeasurement")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<float>("Kcal")
                        .HasColumnType("real");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Proteins")
                        .HasColumnType("real");

                    b.Property<float>("Salt")
                        .HasColumnType("real");

                    b.Property<float>("Sugar")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUnitOfMeasurement");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.IngredientsForRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int?>("IdIngredient")
                        .HasColumnType("int");

                    b.Property<int?>("IdRecipe")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdIngredient");

                    b.HasIndex("IdRecipe");

                    b.ToTable("IngredientsForRecipe");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.Recipes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCuisineType")
                        .HasColumnType("int");

                    b.Property<int?>("IdDifficulty")
                        .HasColumnType("int");

                    b.Property<int?>("IdDishType")
                        .HasColumnType("int");

                    b.Property<int?>("IdImage")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MakingTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCuisineType");

                    b.HasIndex("IdDifficulty");

                    b.HasIndex("IdDishType");

                    b.HasIndex("IdImage");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.RecipeSteps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdRecipe")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdRecipe");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.UnitsOfMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitsOfMeasurement");
                });

            modelBuilder.Entity("FoodBookAPI.Models.Media.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.CuisineType", b =>
                {
                    b.HasOne("FoodBookAPI.Models.Media.Images", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.DishType", b =>
                {
                    b.HasOne("FoodBookAPI.Models.Media.Images", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.Ingredients", b =>
                {
                    b.HasOne("FoodBookAPI.Models.FoodBook.UnitsOfMeasurement", "UnitOfMeasurement")
                        .WithMany()
                        .HasForeignKey("IdUnitOfMeasurement");

                    b.Navigation("UnitOfMeasurement");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.IngredientsForRecipe", b =>
                {
                    b.HasOne("FoodBookAPI.Models.FoodBook.Ingredients", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IdIngredient");

                    b.HasOne("FoodBookAPI.Models.FoodBook.Recipes", "Recipe")
                        .WithMany("IngredientsForRecipe")
                        .HasForeignKey("IdRecipe");

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.Recipes", b =>
                {
                    b.HasOne("FoodBookAPI.Models.FoodBook.CuisineType", "CuisineType")
                        .WithMany()
                        .HasForeignKey("IdCuisineType");

                    b.HasOne("FoodBookAPI.Models.FoodBook.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("IdDifficulty");

                    b.HasOne("FoodBookAPI.Models.FoodBook.DishType", "DishType")
                        .WithMany()
                        .HasForeignKey("IdDishType");

                    b.HasOne("FoodBookAPI.Models.Media.Images", "Image")
                        .WithMany()
                        .HasForeignKey("IdImage");

                    b.Navigation("CuisineType");

                    b.Navigation("Difficulty");

                    b.Navigation("DishType");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.RecipeSteps", b =>
                {
                    b.HasOne("FoodBookAPI.Models.FoodBook.Recipes", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("IdRecipe");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("FoodBookAPI.Models.FoodBook.Recipes", b =>
                {
                    b.Navigation("IngredientsForRecipe");

                    b.Navigation("RecipeSteps");
                });
#pragma warning restore 612, 618
        }
    }
}