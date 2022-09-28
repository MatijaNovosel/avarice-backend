﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using avarice_backend;

namespace avarice_backend.Migrations
{
  [DbContext(typeof(avariceContext))]
  [Migration("20210811220002_Initial")]
  partial class Initial
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasCharSet("latin1")
          .HasAnnotation("Relational:MaxIdentifierLength", 64)
          .HasAnnotation("ProductVersion", "5.0.5");

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
          {
            b.Property<string>("Id")
                      .HasColumnType("varchar(255)");

            b.Property<string>("ConcurrencyStamp")
                      .IsConcurrencyToken()
                      .HasColumnType("longtext");

            b.Property<string>("Name")
                      .HasMaxLength(256)
                      .HasColumnType("varchar(256)");

            b.Property<string>("NormalizedName")
                      .HasMaxLength(256)
                      .HasColumnType("varchar(256)");

            b.HasKey("Id");

            b.HasIndex("NormalizedName")
                      .IsUnique()
                      .HasDatabaseName("RoleNameIndex");

            b.ToTable("AspNetRoles");
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            b.Property<string>("ClaimType")
                      .HasColumnType("longtext");

            b.Property<string>("ClaimValue")
                      .HasColumnType("longtext");

            b.Property<string>("RoleId")
                      .IsRequired()
                      .HasColumnType("varchar(255)");

            b.HasKey("Id");

            b.HasIndex("RoleId");

            b.ToTable("AspNetRoleClaims");
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            b.Property<string>("ClaimType")
                      .HasColumnType("longtext");

            b.Property<string>("ClaimValue")
                      .HasColumnType("longtext");

            b.Property<string>("UserId")
                      .IsRequired()
                      .HasColumnType("varchar(255)");

            b.HasKey("Id");

            b.HasIndex("UserId");

            b.ToTable("AspNetUserClaims");
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
          {
            b.Property<string>("LoginProvider")
                      .HasMaxLength(128)
                      .HasColumnType("varchar(128)");

            b.Property<string>("ProviderKey")
                      .HasMaxLength(128)
                      .HasColumnType("varchar(128)");

            b.Property<string>("ProviderDisplayName")
                      .HasColumnType("longtext");

            b.Property<string>("UserId")
                      .IsRequired()
                      .HasColumnType("varchar(255)");

            b.HasKey("LoginProvider", "ProviderKey");

            b.HasIndex("UserId");

            b.ToTable("AspNetUserLogins");
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
          {
            b.Property<string>("UserId")
                      .HasColumnType("varchar(255)");

            b.Property<string>("RoleId")
                      .HasColumnType("varchar(255)");

            b.HasKey("UserId", "RoleId");

            b.HasIndex("RoleId");

            b.ToTable("AspNetUserRoles");
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
          {
            b.Property<string>("UserId")
                      .HasColumnType("varchar(255)");

            b.Property<string>("LoginProvider")
                      .HasMaxLength(128)
                      .HasColumnType("varchar(128)");

            b.Property<string>("Name")
                      .HasMaxLength(128)
                      .HasColumnType("varchar(128)");

            b.Property<string>("Value")
                      .HasColumnType("longtext");

            b.HasKey("UserId", "LoginProvider", "Name");

            b.ToTable("AspNetUserTokens");
          });

      modelBuilder.Entity("avarice_backend.Account", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int(11)")
                      .HasColumnName("id");

            b.Property<string>("Currency")
                      .IsRequired()
                      .ValueGeneratedOnAdd()
                      .HasMaxLength(32)
                      .HasColumnType("varchar(32)")
                      .HasColumnName("currency")
                      .HasDefaultValueSql("'HRK'");

            b.Property<string>("Name")
                      .HasMaxLength(64)
                      .HasColumnType("varchar(64)")
                      .HasColumnName("name");

            b.Property<string>("UserId")
                      .HasColumnType("varchar(255)")
                      .HasColumnName("userId");

            b.HasKey("Id");

            b.HasIndex(new[] { "UserId" }, "userId");

            b.ToTable("account");

            b
                      .HasCharSet("latin1")
                      .UseCollation("latin1_swedish_ci");
          });

      modelBuilder.Entity("avarice_backend.Category", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int(11)")
                      .HasColumnName("id");

            b.Property<string>("Color")
                      .HasMaxLength(32)
                      .HasColumnType("varchar(32)")
                      .HasColumnName("color");

            b.Property<string>("Icon")
                      .HasMaxLength(32)
                      .HasColumnType("varchar(32)")
                      .HasColumnName("icon");

            b.Property<string>("Name")
                      .HasMaxLength(32)
                      .HasColumnType("varchar(32)")
                      .HasColumnName("name");

            b.Property<string>("UserId")
                      .HasColumnType("varchar(255)")
                      .HasColumnName("userId");

            b.HasKey("Id");

            b.HasIndex("UserId");

            b.ToTable("category");

            b
                      .HasCharSet("latin1")
                      .UseCollation("latin1_swedish_ci");
          });

      modelBuilder.Entity("avarice_backend.Transaction", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int(18)")
                      .HasColumnName("id");

            b.Property<int?>("AccountId")
                      .HasColumnType("int(11)")
                      .HasColumnName("accountId");

            b.Property<double?>("Amount")
                      .HasColumnType("double")
                      .HasColumnName("amount");

            b.Property<int?>("CategoryId")
                      .HasColumnType("int(11)")
                      .HasColumnName("categoryId");

            b.Property<string>("Description")
                      .HasMaxLength(255)
                      .HasColumnType("varchar(255)")
                      .HasColumnName("description");

            b.Property<string>("TransactionType")
                      .HasMaxLength(3)
                      .HasColumnType("varchar(3)")
                      .HasColumnName("transactionType");

            b.Property<string>("UserId")
                      .HasColumnType("varchar(255)")
                      .HasColumnName("userId");

            b.HasKey("Id");

            b.HasIndex(new[] { "AccountId" }, "accountId");

            b.HasIndex(new[] { "CategoryId" }, "categoryId");

            b.HasIndex(new[] { "UserId" }, "userId")
                      .HasDatabaseName("userId1");

            b.ToTable("transaction");

            b
                      .HasCharSet("latin1")
                      .UseCollation("latin1_swedish_ci");
          });

      modelBuilder.Entity("avarice_backend.User", b =>
          {
            b.Property<string>("Id")
                      .HasColumnType("varchar(255)");

            b.Property<int>("AccessFailedCount")
                      .HasColumnType("int");

            b.Property<string>("ConcurrencyStamp")
                      .IsConcurrencyToken()
                      .HasColumnType("longtext");

            b.Property<string>("Email")
                      .HasMaxLength(256)
                      .HasColumnType("varchar(256)");

            b.Property<bool>("EmailConfirmed")
                      .HasColumnType("tinyint(1)");

            b.Property<bool>("LockoutEnabled")
                      .HasColumnType("tinyint(1)");

            b.Property<DateTimeOffset?>("LockoutEnd")
                      .HasColumnType("datetime(6)");

            b.Property<string>("NormalizedEmail")
                      .HasMaxLength(256)
                      .HasColumnType("varchar(256)");

            b.Property<string>("NormalizedUserName")
                      .HasMaxLength(256)
                      .HasColumnType("varchar(256)");

            b.Property<string>("PasswordHash")
                      .HasColumnType("longtext");

            b.Property<string>("PhoneNumber")
                      .HasColumnType("longtext");

            b.Property<bool>("PhoneNumberConfirmed")
                      .HasColumnType("tinyint(1)");

            b.Property<string>("SecurityStamp")
                      .HasColumnType("longtext");

            b.Property<bool>("TwoFactorEnabled")
                      .HasColumnType("tinyint(1)");

            b.Property<string>("UserName")
                      .HasMaxLength(256)
                      .HasColumnType("varchar(256)");

            b.HasKey("Id");

            b.HasIndex("NormalizedEmail")
                      .HasDatabaseName("EmailIndex");

            b.HasIndex("NormalizedUserName")
                      .IsUnique()
                      .HasDatabaseName("UserNameIndex");

            b.ToTable("AspNetUsers");
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
          {
            b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                      .WithMany()
                      .HasForeignKey("RoleId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
          {
            b.HasOne("avarice_backend.User", null)
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
          {
            b.HasOne("avarice_backend.User", null)
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
          {
            b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                      .WithMany()
                      .HasForeignKey("RoleId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("avarice_backend.User", null)
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
          {
            b.HasOne("avarice_backend.User", null)
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("avarice_backend.Account", b =>
          {
            b.HasOne("avarice_backend.User", "User")
                      .WithMany("Accounts")
                      .HasForeignKey("UserId")
                      .HasConstraintName("account_ibfk_1");

            b.Navigation("User");
          });

      modelBuilder.Entity("avarice_backend.Category", b =>
          {
            b.HasOne("avarice_backend.User", "User")
                      .WithMany("Categories")
                      .HasForeignKey("UserId")
                      .HasConstraintName("category_ibfk_1");

            b.Navigation("User");
          });

      modelBuilder.Entity("avarice_backend.Transaction", b =>
          {
            b.HasOne("avarice_backend.Account", "Account")
                      .WithMany("Transactions")
                      .HasForeignKey("AccountId")
                      .HasConstraintName("transaction_ibfk_2");

            b.HasOne("avarice_backend.Category", "Category")
                      .WithMany("Transactions")
                      .HasForeignKey("CategoryId")
                      .HasConstraintName("transaction_ibfk_3");

            b.HasOne("avarice_backend.User", "User")
                      .WithMany("Transactions")
                      .HasForeignKey("UserId")
                      .HasConstraintName("transaction_ibfk_1");

            b.Navigation("Account");

            b.Navigation("Category");

            b.Navigation("User");
          });

      modelBuilder.Entity("avarice_backend.Account", b =>
          {
            b.Navigation("Transactions");
          });

      modelBuilder.Entity("avarice_backend.Category", b =>
          {
            b.Navigation("Transactions");
          });

      modelBuilder.Entity("avarice_backend.User", b =>
          {
            b.Navigation("Accounts");

            b.Navigation("Categories");

            b.Navigation("Transactions");
          });
#pragma warning restore 612, 618
    }
  }
}
