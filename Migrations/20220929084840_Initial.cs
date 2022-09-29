using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    currency = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, defaultValueSql: "'HRK'", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    initialBalance = table.Column<double>(type: "double", nullable: false),
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
                        principalColumn: "Id");
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
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    icon = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    color = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    system = table.Column<ulong>(type: "bit", nullable: false, defaultValue: 0ul),
                    parentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "category_ibfk_1",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "category_ibfk_2",
                        column: x => x.parentId,
                        principalTable: "category",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "template",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    amount = table.Column<double>(type: "double", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    accountId = table.Column<long>(type: "bigint", nullable: false),
                    transferAccountId = table.Column<long>(type: "bigint", nullable: true),
                    categoryId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    Longitude = table.Column<double>(type: "double", nullable: true),
                    Latitude = table.Column<double>(type: "double", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_template", x => x.id);
                    table.ForeignKey(
                        name: "template_ibfk_1",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "template_ibfk_2",
                        column: x => x.transferAccountId,
                        principalTable: "account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "template_ibfk_3",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "template_ibfk_4",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    amount = table.Column<double>(type: "double", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    accountId = table.Column<long>(type: "bigint", nullable: false),
                    transferAccountId = table.Column<long>(type: "bigint", nullable: true),
                    categoryId = table.Column<long>(type: "bigint", nullable: false),
                    longitude = table.Column<double>(type: "double", nullable: true),
                    latitude = table.Column<double>(type: "double", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "transaction_ibfk_1",
                        column: x => x.accountId,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "transaction_ibfk_2",
                        column: x => x.transferAccountId,
                        principalTable: "account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "transaction_ibfk_3",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b2beece6-28da-4c7f-b304-3a526d166f00", 0, "48ad95fa-743a-4673-8927-5044d96b7717", "mnovosel5@gmail.com", true, false, null, "MNOVOSEL5@GMAIL.COM", null, "AQAAAAEAACcQAAAAEHHZcifrXCQ1DciNISJi3aJgQJW+jyI+G66JPqVhhqfdn/wHXaXr8tQ0IK+F1iVJCw==", null, false, "M5INRPR3EKT2FOPSOKK2PJZMR4A3AKYN", false, "matija" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "parentId", "system", "userId" },
                values: new object[] { 1L, "grey", "mdi-swap-horizontal", "Transfer", null, 1ul, null });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "id", "currency", "initialBalance", "name", "userId" },
                values: new object[,]
                {
                    { 1L, "HRK", 14000.0, "Gyro", "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 2L, "EUR", 200.0, "Euros", "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 3L, "HRK", 0.0, "Checking", "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 4L, "HRK", 800.0, "Pocket", "b2beece6-28da-4c7f-b304-3a526d166f00" }
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
                values: new object[,]
                {
                    { 2L, "#ffffff", "mdi-food-fork-drink", "Food & Drinks", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 7L, "#ffffff", "mdi-basket", "Shopping", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 19L, "#ffffff", "mdi-home", "Housing", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 20L, "#ffffff", "mdi-lightbulb", "Energy, utilities", 20L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 26L, "#ffffff", "mdi-bus", "Transportation", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 31L, "#ffffff", "mdi-car", "Vehicle", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 38L, "#ffffff", "mdi-account", "Life & Entertainment", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 54L, "#ffffff", "mdi-laptop", "Communication, PC", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 60L, "#ffffff", "mdi-currency-usd", "Financial expenses", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 68L, "#ffffff", "mdi-chart-line", "Investments", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 74L, "#ffffff", "mdi-currency-usd", "Income", null, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 86L, "#ffffff", "mdi-account-question", "Others", null, "b2beece6-28da-4c7f-b304-3a526d166f00" }
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
                values: new object[,]
                {
                    { 3L, "#ffffff", "mdi-food", "Restaurant, fast-food", 2L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 4L, "#ffffff", "mdi-glass-cocktail", "Bar, cafe", 2L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 6L, "#ffffff", "mdi-cart", "Groceries", 2L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 8L, "#ffffff", "mdi-tshirt-crew", "Clothes and shoes", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 9L, "#ffffff", "mdi-pill", "Drug-store, chemist", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 10L, "#ffffff", "mdi-laptop", "Electronics, accessories", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 11L, "#ffffff", "mdi-emoticon", "Free time", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 12L, "#ffffff", "mdi-gift", "Gifts, joy", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 13L, "#ffffff", "mdi-bottle-tonic-plus", "Health and beauty", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 14L, "#ffffff", "mdi-home", "Home, garden", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 15L, "#ffffff", "mdi-diamond-stone", "Jewels, accessories", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 16L, "#ffffff", "mdi-baby-carriage", "Kids", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 17L, "#ffffff", "mdi-paw", "Pets, animals", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 18L, "#ffffff", "mdi-hammer-screwdriver", "Stationery, tools", 7L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 21L, "#ffffff", "mdi-hammer", "Maintenance, repairs", 20L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 22L, "#ffffff", "mdi-bank-plus", "Mortgage", 20L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 23L, "#ffffff", "mdi-shield-home", "Property insurance", 20L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 24L, "#ffffff", "mdi-key-variant", "Rent", 20L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 25L, "#ffffff", "mdi-home-circle-outline", "Services", 20L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 27L, "#ffffff", "mdi-bag-suitcase", "Business trips", 26L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 28L, "#ffffff", "mdi-airplane", "Long distance", 26L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 29L, "#ffffff", "mdi-tram", "Public transport", 26L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 30L, "#ffffff", "mdi-taxi", "Taxi", 26L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 32L, "#ffffff", "mdi-fuel", "Fuel", 31L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 33L, "#ffffff", "mdi-car", "Leasing", 31L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 34L, "#ffffff", "mdi-parking", "Parking", 31L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 35L, "#ffffff", "mdi-key", "Rentals", 31L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 36L, "#ffffff", "mdi-shield-car", "Vehicle insurance", 31L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 37L, "#ffffff", "mdi-tools", "Vehicle maintenance", 31L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 39L, "#ffffff", "mdi-dumbbell", "Active sport, fitness", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 40L, "#ffffff", "mdi-cup", "Alcohol, tobacco", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 41L, "#ffffff", "mdi-book-open-variant", "Books, audio, subscriptions", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 43L, "#ffffff", "mdi-gift", "Charity, gifts", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 44L, "#ffffff", "mdi-drama-masks", "Culture, sports events", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 45L, "#ffffff", "mdi-school", "Education, development", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 46L, "#ffffff", "mdi-doctor", "Health care, doctor", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 47L, "#ffffff", "mdi-heart", "Hobbies", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 48L, "#ffffff", "mdi-palm-tree", "Holiday, trips, hotels", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 49L, "#ffffff", "mdi-cake", "Life events", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 50L, "#ffffff", "mdi-dice-5", "Lottery, gambling", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 51L, "#ffffff", "mdi-television-classic", "TV, Streaming", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 52L, "#ffffff", "mdi-flower", "Wellness, beauty", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 53L, "#ffffff", "mdi-basketball", "Culture, sport events", 38L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 55L, "#ffffff", "mdi-wifi", "Internet", 54L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 56L, "#ffffff", "mdi-phone", "Phone, cell phone", 54L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 57L, "#ffffff", "mdi-email", "Postal services", 54L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 58L, "#ffffff", "mdi-controller-classic", "Software, apps, games", 54L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 59L, "#ffffff", "mdi-controller-classic", "Games", 54L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 61L, "#ffffff", "mdi-account-alert", "Advisory", 60L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 62L, "#ffffff", "mdi-comment-remove", "Charges, Fees", 60L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 63L, "#ffffff", "mdi-account-child", "Child Support", 60L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 64L, "#ffffff", "mdi-alert-circle", "Fines", 60L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 65L, "#ffffff", "mdi-card-bulleted", "Insurances", 60L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 66L, "#ffffff", "mdi-cards", "Loan, interests", 60L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 67L, "#ffffff", "mdi-content-cut", "Taxes", 60L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 69L, "#ffffff", "mdi-image", "Collections", 68L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 70L, "#ffffff", "mdi-chart-multiple", "Financial investments", 68L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 71L, "#ffffff", "mdi-domain", "Realty", 68L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 72L, "#ffffff", "mdi-account-cash", "Savings", 68L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 73L, "#ffffff", "mdi-car", "Vehicles, chattels", 68L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 75L, "#ffffff", "mdi-newspaper", "Checks, coupons", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 76L, "#ffffff", "mdi-account-child", "Child Support", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 77L, "#ffffff", "mdi-check-decagram", "Dues & grants", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 78L, "#ffffff", "mdi-gift", "Gifts", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 79L, "#ffffff", "mdi-ticket-percent", "Interests, dividends", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 80L, "#ffffff", "mdi-currency-usd", "Lending, renting", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 81L, "#ffffff", "mdi-dice-5", "Lottery, gambling", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 82L, "#ffffff", "mdi-undo", "Refunds (tax, purchase)", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 83L, "#ffffff", "mdi-home", "Rental income", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 84L, "#ffffff", "mdi-sale", "Sale", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 85L, "#ffffff", "mdi-currency-usd", "Wage, invoices", 74L, "b2beece6-28da-4c7f-b304-3a526d166f00" }
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
                values: new object[] { 87L, "#ffffff", "mdi-help-circle", "Missing", 85L, "b2beece6-28da-4c7f-b304-3a526d166f00" });

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
                name: "IX_category_parentId",
                table: "category",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_category_userId",
                table: "category",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "accountId",
                table: "template",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "categoryId",
                table: "template",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_template_transferAccountId",
                table: "template",
                column: "transferAccountId");

            migrationBuilder.CreateIndex(
                name: "latitude",
                table: "template",
                column: "Latitude");

            migrationBuilder.CreateIndex(
                name: "longitude",
                table: "template",
                column: "Longitude");

            migrationBuilder.CreateIndex(
                name: "userId1",
                table: "template",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "accountId1",
                table: "transaction",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "categoryId1",
                table: "transaction",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_transferAccountId",
                table: "transaction",
                column: "transferAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_UserId",
                table: "transaction",
                column: "UserId");
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
                name: "template");

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
