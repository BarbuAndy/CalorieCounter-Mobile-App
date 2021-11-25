﻿// <auto-generated />
using System;
using CC.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CC.Migrations
{
    [DbContext(typeof(CCDbContext))]
    [Migration("20211025105412_AddedDateInUserData")]
    partial class AddedDateInUserData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CC.DbModels.ActivityLevel", b =>
                {
                    b.Property<int>("activityLevelId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("activityLevelId");

                    b.ToTable("ActivityLevel");
                });

            modelBuilder.Entity("CC.DbModels.FoodItem", b =>
                {
                    b.Property<int>("foodItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("calories")
                        .HasColumnType("int");

                    b.Property<float>("carbohydrates")
                        .HasColumnType("real");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("fats")
                        .HasColumnType("real");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("protein")
                        .HasColumnType("real");

                    b.Property<bool>("published")
                        .HasColumnType("bit");

                    b.Property<int>("timesFlaggedWrong")
                        .HasColumnType("int");

                    b.HasKey("foodItemId");

                    b.ToTable("FoodItem");
                });

            modelBuilder.Entity("CC.DbModels.FoodItemConsumed", b =>
                {
                    b.Property<int>("foodItemConsumedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("foodItemId")
                        .HasColumnType("int");

                    b.Property<string>("meal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("foodItemConsumedId");

                    b.HasIndex("foodItemId");

                    b.HasIndex("userId");

                    b.ToTable("FoodItemConsumed");
                });

            modelBuilder.Entity("CC.DbModels.Goal", b =>
                {
                    b.Property<int>("goalId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("goalId");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("CC.DbModels.PrefferedDiet", b =>
                {
                    b.Property<int>("prefferedDietId")
                        .HasColumnType("int");

                    b.Property<int>("carbohydratePercentage")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fatsPercentage")
                        .HasColumnType("int");

                    b.Property<int>("proteinPercentage")
                        .HasColumnType("int");

                    b.HasKey("prefferedDietId");

                    b.ToTable("PrefferedDiet");
                });

            modelBuilder.Entity("CC.DbModels.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CC.DbModels.UserData", b =>
                {
                    b.Property<int>("userDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("activityLevelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateSet")
                        .HasColumnType("datetime2");

                    b.Property<int?>("goalId")
                        .HasColumnType("int");

                    b.Property<int?>("prefferedDietId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("userDataId");

                    b.HasIndex("activityLevelId");

                    b.HasIndex("goalId");

                    b.HasIndex("prefferedDietId");

                    b.HasIndex("userId");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("CC.DbModels.FoodItemConsumed", b =>
                {
                    b.HasOne("CC.DbModels.FoodItem", "foodItem")
                        .WithMany()
                        .HasForeignKey("foodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CC.DbModels.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("foodItem");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CC.DbModels.UserData", b =>
                {
                    b.HasOne("CC.DbModels.ActivityLevel", "activityLevel")
                        .WithMany()
                        .HasForeignKey("activityLevelId");

                    b.HasOne("CC.DbModels.Goal", "goal")
                        .WithMany()
                        .HasForeignKey("goalId");

                    b.HasOne("CC.DbModels.PrefferedDiet", "prefferedDiet")
                        .WithMany()
                        .HasForeignKey("prefferedDietId");

                    b.HasOne("CC.DbModels.User", null)
                        .WithMany("userData")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("activityLevel");

                    b.Navigation("goal");

                    b.Navigation("prefferedDiet");
                });

            modelBuilder.Entity("CC.DbModels.User", b =>
                {
                    b.Navigation("userData");
                });
#pragma warning restore 612, 618
        }
    }
}