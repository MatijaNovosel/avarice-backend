using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fin_app_backend.Migrations
{
    public partial class Templates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "userId1",
                table: "transaction",
                newName: "userId2");

            migrationBuilder.RenameIndex(
                name: "categoryId",
                table: "transaction",
                newName: "categoryId1");

            migrationBuilder.RenameIndex(
                name: "accountId",
                table: "transaction",
                newName: "accountId1");

            migrationBuilder.CreateTable(
                name: "template",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    amount = table.Column<double>(type: "double", nullable: true),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    transactionType = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    accountId = table.Column<long>(type: "bigint", nullable: false),
                    transferAccountId = table.Column<long>(type: "bigint", nullable: true),
                    categoryId = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "template_ibfk_3",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "template_ibfk_4",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "id", "balance", "currency", "name", "userId" },
                values: new object[,]
                {
                    { 3L, 0.0, "HRK", "Checking", "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 4L, 800.0, "HRK", "Pocket", "ee103364-7617-4474-889e-320838e5f3a5" }
                });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 1L,
                column: "system",
                value: 1ul);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "color", "name" },
                values: new object[] { "#ffffff", "Food" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
                values: new object[] { 3L, "#ffffff", "mdi-file", "Restaurant", 2L, "ee103364-7617-4474-889e-320838e5f3a5" });

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
                name: "userId1",
                table: "template",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "template");

            migrationBuilder.DeleteData(
                table: "account",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "account",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.RenameIndex(
                name: "userId2",
                table: "transaction",
                newName: "userId1");

            migrationBuilder.RenameIndex(
                name: "categoryId1",
                table: "transaction",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "accountId1",
                table: "transaction",
                newName: "accountId");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 1L,
                column: "system",
                value: 0ul);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "color", "name" },
                values: new object[] { "red", "Testing category" });
        }
    }
}
