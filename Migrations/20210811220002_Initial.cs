using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace avarice_backend.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
          .Annotation("MySql:CharSet", "latin1");

      migrationBuilder.CreateTable(
          name: "AspNetRoles",
          columns: table => new
          {
            Id = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetRoles", x => x.Id);
          })
          .Annotation("MySql:CharSet", "latin1");

      migrationBuilder.CreateTable(
          name: "AspNetUsers",
          columns: table => new
          {
            Id = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
            PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
            TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
            LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
            LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
            AccessFailedCount = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUsers", x => x.Id);
          })
          .Annotation("MySql:CharSet", "latin1");

      migrationBuilder.CreateTable(
          name: "AspNetRoleClaims",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            ClaimType = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            table.ForeignKey(
                      name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                      column: x => x.RoleId,
                      principalTable: "AspNetRoles",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "latin1");

      migrationBuilder.CreateTable(
          name: "account",
          columns: table => new
          {
            id = table.Column<int>(type: "int(11)", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            currency = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, defaultValueSql: "'HRK'", collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1"),
            name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1"),
            userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_account", x => x.id);
            table.ForeignKey(
                      name: "account_ibfk_1",
                      column: x => x.userId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          })
          .Annotation("MySql:CharSet", "latin1")
          .Annotation("Relational:Collation", "latin1_swedish_ci");

      migrationBuilder.CreateTable(
          name: "AspNetUserClaims",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            ClaimType = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            table.ForeignKey(
                      name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "latin1");

      migrationBuilder.CreateTable(
          name: "AspNetUserLogins",
          columns: table => new
          {
            LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1"),
            UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            table.ForeignKey(
                      name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "latin1");

      migrationBuilder.CreateTable(
          name: "AspNetUserRoles",
          columns: table => new
          {
            UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            table.ForeignKey(
                      name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                      column: x => x.RoleId,
                      principalTable: "AspNetRoles",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "latin1");

      migrationBuilder.CreateTable(
          name: "AspNetUserTokens",
          columns: table => new
          {
            UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                  .Annotation("MySql:CharSet", "latin1"),
            Value = table.Column<string>(type: "longtext", nullable: true)
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            table.ForeignKey(
                      name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          })
          .Annotation("MySql:CharSet", "latin1");

      migrationBuilder.CreateTable(
          name: "category",
          columns: table => new
          {
            id = table.Column<int>(type: "int(11)", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1"),
            icon = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1"),
            color = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1"),
            userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_category", x => x.id);
            table.ForeignKey(
                      name: "category_ibfk_1",
                      column: x => x.userId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          })
          .Annotation("MySql:CharSet", "latin1")
          .Annotation("Relational:Collation", "latin1_swedish_ci");

      migrationBuilder.CreateTable(
          name: "transaction",
          columns: table => new
          {
            id = table.Column<int>(type: "int(18)", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            amount = table.Column<double>(type: "double", nullable: true),
            description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1"),
            transactionType = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1"),
            accountId = table.Column<int>(type: "int(11)", nullable: true),
            categoryId = table.Column<int>(type: "int(11)", nullable: true),
            userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "latin1_swedish_ci")
                  .Annotation("MySql:CharSet", "latin1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_transaction", x => x.id);
            table.ForeignKey(
                      name: "transaction_ibfk_1",
                      column: x => x.userId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "transaction_ibfk_2",
                      column: x => x.accountId,
                      principalTable: "account",
                      principalColumn: "id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "transaction_ibfk_3",
                      column: x => x.categoryId,
                      principalTable: "category",
                      principalColumn: "id",
                      onDelete: ReferentialAction.Restrict);
          })
          .Annotation("MySql:CharSet", "latin1")
          .Annotation("Relational:Collation", "latin1_swedish_ci");

      migrationBuilder.CreateIndex(
          name: "userId",
          table: "account",
          column: "userId");

      migrationBuilder.CreateIndex(
          name: "IX_AspNetRoleClaims_RoleId",
          table: "AspNetRoleClaims",
          column: "RoleId");

      migrationBuilder.CreateIndex(
          name: "RoleNameIndex",
          table: "AspNetRoles",
          column: "NormalizedName",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_AspNetUserClaims_UserId",
          table: "AspNetUserClaims",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_AspNetUserLogins_UserId",
          table: "AspNetUserLogins",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_AspNetUserRoles_RoleId",
          table: "AspNetUserRoles",
          column: "RoleId");

      migrationBuilder.CreateIndex(
          name: "EmailIndex",
          table: "AspNetUsers",
          column: "NormalizedEmail");

      migrationBuilder.CreateIndex(
          name: "UserNameIndex",
          table: "AspNetUsers",
          column: "NormalizedUserName",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_category_userId",
          table: "category",
          column: "userId");

      migrationBuilder.CreateIndex(
          name: "accountId",
          table: "transaction",
          column: "accountId");

      migrationBuilder.CreateIndex(
          name: "categoryId",
          table: "transaction",
          column: "categoryId");

      migrationBuilder.CreateIndex(
          name: "userId1",
          table: "transaction",
          column: "userId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "AspNetRoleClaims");

      migrationBuilder.DropTable(
          name: "AspNetUserClaims");

      migrationBuilder.DropTable(
          name: "AspNetUserLogins");

      migrationBuilder.DropTable(
          name: "AspNetUserRoles");

      migrationBuilder.DropTable(
          name: "AspNetUserTokens");

      migrationBuilder.DropTable(
          name: "transaction");

      migrationBuilder.DropTable(
          name: "AspNetRoles");

      migrationBuilder.DropTable(
          name: "account");

      migrationBuilder.DropTable(
          name: "category");

      migrationBuilder.DropTable(
          name: "AspNetUsers");
    }
  }
}
