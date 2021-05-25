﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fin_app_backend;

namespace fin_app_backend.Migrations
{
    [DbContext(typeof(finappContext))]
    [Migration("20210525232241_Authentication")]
    partial class Authentication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("latin1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

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

            modelBuilder.Entity("fin_app_backend.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("currency")
                        .HasDefaultValueSql("'HRK'");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("icon")
                        .HasDefaultValueSql("'eye'");

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

            modelBuilder.Entity("fin_app_backend.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("AccountId")
                        .HasColumnType("int(11)")
                        .HasColumnName("accountId");

                    b.Property<double>("Amount")
                        .HasColumnType("double")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AccountId" }, "accountId");

                    b.HasIndex(new[] { "UserId" }, "userId")
                        .HasDatabaseName("userId1");

                    b.ToTable("history");

                    b
                        .HasCharSet("latin1")
                        .UseCollation("latin1_swedish_ci");
                });

            modelBuilder.Entity("fin_app_backend.Locale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Text")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.ToTable("locale");

                    b
                        .HasCharSet("latin1")
                        .UseCollation("latin1_swedish_ci");
                });

            modelBuilder.Entity("fin_app_backend.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<bool?>("DarkMode")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("darkMode");

                    b.Property<string>("DateFormat")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("dateFormat")
                        .HasDefaultValueSql("'dd.MM.yyyy. HH:mm'");

                    b.Property<int?>("LocaleId")
                        .HasColumnType("int(11)")
                        .HasColumnName("localeId");

                    b.Property<string>("PreferredCurrency")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("preferredCurrency")
                        .HasDefaultValueSql("'HRK'");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "LocaleId" }, "settings_ibfk_2");

                    b.HasIndex(new[] { "UserId" }, "userId")
                        .HasDatabaseName("userId2");

                    b.ToTable("settings");

                    b
                        .HasCharSet("latin1")
                        .UseCollation("latin1_swedish_ci");
                });

            modelBuilder.Entity("fin_app_backend.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<sbyte?>("System")
                        .HasColumnType("tinyint");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "userId")
                        .HasDatabaseName("userId3");

                    b.ToTable("tag");

                    b
                        .HasCharSet("latin1")
                        .UseCollation("latin1_swedish_ci");
                });

            modelBuilder.Entity("fin_app_backend.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("AccountId")
                        .HasColumnType("int(11)")
                        .HasColumnName("accountId");

                    b.Property<double?>("Amount")
                        .HasColumnType("double")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<bool?>("Expense")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("expense");

                    b.Property<sbyte>("Transfer")
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("transfer");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AccountId" }, "accountId")
                        .HasDatabaseName("accountId1");

                    b.HasIndex(new[] { "UserId" }, "userId")
                        .HasDatabaseName("userId4");

                    b.ToTable("transaction");

                    b
                        .HasCharSet("latin1")
                        .UseCollation("latin1_swedish_ci");
                });

            modelBuilder.Entity("fin_app_backend.Transactiontag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int?>("TagId")
                        .HasColumnType("int(11)")
                        .HasColumnName("tagId");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int(11)")
                        .HasColumnName("transactionId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TagId" }, "tagId");

                    b.HasIndex(new[] { "TransactionId" }, "transactionId");

                    b.ToTable("transactiontag");

                    b
                        .HasCharSet("latin1")
                        .UseCollation("latin1_swedish_ci");
                });

            modelBuilder.Entity("fin_app_backend.User", b =>
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
                    b.HasOne("fin_app_backend.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("fin_app_backend.User", null)
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

                    b.HasOne("fin_app_backend.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("fin_app_backend.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("fin_app_backend.Account", b =>
                {
                    b.HasOne("fin_app_backend.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("account_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("fin_app_backend.History", b =>
                {
                    b.HasOne("fin_app_backend.Account", "Account")
                        .WithMany("Histories")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("history_ibfk_1");

                    b.HasOne("fin_app_backend.User", "User")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .HasConstraintName("history_ibfk_2");

                    b.Navigation("Account");

                    b.Navigation("User");
                });

            modelBuilder.Entity("fin_app_backend.Setting", b =>
                {
                    b.HasOne("fin_app_backend.Locale", "Locale")
                        .WithMany("Settings")
                        .HasForeignKey("LocaleId")
                        .HasConstraintName("settings_ibfk_2");

                    b.HasOne("fin_app_backend.User", "User")
                        .WithMany("Settings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("settings_ibfk_1");

                    b.Navigation("Locale");

                    b.Navigation("User");
                });

            modelBuilder.Entity("fin_app_backend.Tag", b =>
                {
                    b.HasOne("fin_app_backend.User", "User")
                        .WithMany("Tags")
                        .HasForeignKey("UserId")
                        .HasConstraintName("tag_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("fin_app_backend.Transaction", b =>
                {
                    b.HasOne("fin_app_backend.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("transaction_ibfk_2");

                    b.HasOne("fin_app_backend.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("transaction_ibfk_1");

                    b.Navigation("Account");

                    b.Navigation("User");
                });

            modelBuilder.Entity("fin_app_backend.Transactiontag", b =>
                {
                    b.HasOne("fin_app_backend.Tag", "Tag")
                        .WithMany("Transactiontags")
                        .HasForeignKey("TagId")
                        .HasConstraintName("transactiontag_ibfk_2");

                    b.HasOne("fin_app_backend.Transaction", "Transaction")
                        .WithMany("Transactiontags")
                        .HasForeignKey("TransactionId")
                        .HasConstraintName("transactiontag_ibfk_1");

                    b.Navigation("Tag");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("fin_app_backend.Account", b =>
                {
                    b.Navigation("Histories");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("fin_app_backend.Locale", b =>
                {
                    b.Navigation("Settings");
                });

            modelBuilder.Entity("fin_app_backend.Tag", b =>
                {
                    b.Navigation("Transactiontags");
                });

            modelBuilder.Entity("fin_app_backend.Transaction", b =>
                {
                    b.Navigation("Transactiontags");
                });

            modelBuilder.Entity("fin_app_backend.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Histories");

                    b.Navigation("Settings");

                    b.Navigation("Tags");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
