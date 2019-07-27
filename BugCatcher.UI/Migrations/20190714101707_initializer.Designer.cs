﻿// <auto-generated />
using System;
using BugCatcher.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BugCatcher.UI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190714101707_initializer")]
    partial class initializer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BugCatcher.Entities.Concrete.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ItemCommentsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<int>("ItemId");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemComments");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignedUserId");

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<DateTime>("Deadline");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastUpdatedUserId");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<int?>("PriorityId");

                    b.Property<int?>("ProjectId");

                    b.Property<int?>("SprintId");

                    b.Property<int?>("StageId");

                    b.Property<int?>("StatusId");

                    b.Property<int?>("TeamId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("CreUserId");

                    b.HasIndex("LastUpdatedUserId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SprintId");

                    b.HasIndex("StageId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TeamId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ItemFileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.Property<bool>("IsActive");

                    b.Property<int>("ItemId");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemFiles");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ItemSubscribersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("ItemId");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("ItemSubscribers");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.LogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<string>("IP")
                        .HasMaxLength(20);

                    b.Property<bool>("IsActive");

                    b.Property<int>("Level");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.PriorityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<int>("Level");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ProjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ProjectSubscribersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<int?>("ProjectId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectSubscribers");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.QueryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Queries");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.SprintEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Sprint");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.StageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.StatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.TeamEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.CategoryEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ItemCommentsEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("BugCatcher.Entities.Concrete.ItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ItemEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "AssignedUser")
                        .WithMany()
                        .HasForeignKey("AssignedUserId");

                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "LastUpdatedUser")
                        .WithMany()
                        .HasForeignKey("LastUpdatedUserId");

                    b.HasOne("BugCatcher.Entities.Concrete.PriorityEntity", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("BugCatcher.Entities.Concrete.ProjectEntity", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("BugCatcher.Entities.Concrete.SprintEntity", "Sprint")
                        .WithMany()
                        .HasForeignKey("SprintId");

                    b.HasOne("BugCatcher.Entities.Concrete.StageEntity", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId");

                    b.HasOne("BugCatcher.Entities.Concrete.StatusEntity", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("BugCatcher.Entities.Concrete.TeamEntity", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ItemFileEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("BugCatcher.Entities.Concrete.ItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ItemSubscribersEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("BugCatcher.Entities.Concrete.ItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.LogEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.PriorityEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ProjectEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.ProjectSubscribersEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("BugCatcher.Entities.Concrete.ProjectEntity", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.QueryEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.SprintEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.StageEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.StatusEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.TeamEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("BugCatcher.Entities.Concrete.UserEntity", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BugCatcher.Entities.Concrete.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}