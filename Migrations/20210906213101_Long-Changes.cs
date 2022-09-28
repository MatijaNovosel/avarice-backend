using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace avarice_backend.Migrations
{
  public partial class LongChanges : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_1",
          table: "transaction");

      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_2",
          table: "transaction");

      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_4",
          table: "transaction");

      migrationBuilder.DeleteData(
          table: "account",
          keyColumn: "id",
          keyValue: 1);

      migrationBuilder.DeleteData(
          table: "account",
          keyColumn: "id",
          keyValue: 2);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 1);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 2);

      migrationBuilder.AlterColumn<long>(
          name: "transferAccountId",
          table: "transaction",
          type: "bigint",
          nullable: false,
          defaultValue: 0L,
          oldClrType: typeof(int),
          oldType: "int(11)",
          oldNullable: true);

      migrationBuilder.AlterColumn<long>(
          name: "categoryId",
          table: "transaction",
          type: "bigint",
          nullable: false,
          defaultValue: 0L,
          oldClrType: typeof(int),
          oldType: "int(11)",
          oldNullable: true);

      migrationBuilder.AlterColumn<long>(
          name: "accountId",
          table: "transaction",
          type: "bigint",
          nullable: false,
          defaultValue: 0L,
          oldClrType: typeof(int),
          oldType: "int(11)",
          oldNullable: true);

      migrationBuilder.AlterColumn<long>(
          name: "id",
          table: "category",
          type: "bigint",
          nullable: false,
          oldClrType: typeof(int),
          oldType: "int(11)")
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.AlterColumn<long>(
          name: "id",
          table: "account",
          type: "bigint",
          nullable: false,
          oldClrType: typeof(int),
          oldType: "int(11)")
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.InsertData(
          table: "account",
          columns: new[] { "id", "balance", "currency", "name", "userId" },
          values: new object[,]
          {
                    { 1L, 14000.0, "HRK", "Gyro", "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 2L, 200.0, "EUR", "Euros", "ee103364-7617-4474-889e-320838e5f3a5" }
          });

      migrationBuilder.InsertData(
          table: "category",
          columns: new[] { "id", "color", "icon", "name", "userId" },
          values: new object[,]
          {
                    { 1L, "grey", "mdi-swap-horizontal", "Transfer", null },
                    { 2L, "red", "mdi-account", "Testing category", "ee103364-7617-4474-889e-320838e5f3a5" }
          });

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_1",
          table: "transaction",
          column: "accountId",
          principalTable: "account",
          principalColumn: "id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_2",
          table: "transaction",
          column: "transferAccountId",
          principalTable: "account",
          principalColumn: "id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_4",
          table: "transaction",
          column: "categoryId",
          principalTable: "category",
          principalColumn: "id",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_1",
          table: "transaction");

      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_2",
          table: "transaction");

      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_4",
          table: "transaction");

      migrationBuilder.DeleteData(
          table: "account",
          keyColumn: "id",
          keyValue: 1L);

      migrationBuilder.DeleteData(
          table: "account",
          keyColumn: "id",
          keyValue: 2L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 1L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 2L);

      migrationBuilder.AlterColumn<int>(
          name: "transferAccountId",
          table: "transaction",
          type: "int(11)",
          nullable: true,
          oldClrType: typeof(long),
          oldType: "bigint");

      migrationBuilder.AlterColumn<int>(
          name: "categoryId",
          table: "transaction",
          type: "int(11)",
          nullable: true,
          oldClrType: typeof(long),
          oldType: "bigint");

      migrationBuilder.AlterColumn<int>(
          name: "accountId",
          table: "transaction",
          type: "int(11)",
          nullable: true,
          oldClrType: typeof(long),
          oldType: "bigint");

      migrationBuilder.AlterColumn<int>(
          name: "id",
          table: "category",
          type: "int(11)",
          nullable: false,
          oldClrType: typeof(long),
          oldType: "bigint")
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.AlterColumn<int>(
          name: "id",
          table: "account",
          type: "int(11)",
          nullable: false,
          oldClrType: typeof(long),
          oldType: "bigint")
          .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
          .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

      migrationBuilder.InsertData(
          table: "account",
          columns: new[] { "id", "balance", "currency", "name", "userId" },
          values: new object[,]
          {
                    { 1, 14000.0, "HRK", "Gyro", "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 2, 200.0, "EUR", "Euros", "ee103364-7617-4474-889e-320838e5f3a5" }
          });

      migrationBuilder.InsertData(
          table: "category",
          columns: new[] { "id", "color", "icon", "name", "userId" },
          values: new object[,]
          {
                    { 1, "grey", "mdi-swap-horizontal", "Transfer", null },
                    { 2, "red", "mdi-account", "Testing category", "ee103364-7617-4474-889e-320838e5f3a5" }
          });

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_1",
          table: "transaction",
          column: "accountId",
          principalTable: "account",
          principalColumn: "id",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_2",
          table: "transaction",
          column: "transferAccountId",
          principalTable: "account",
          principalColumn: "id",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_4",
          table: "transaction",
          column: "categoryId",
          principalTable: "category",
          principalColumn: "id",
          onDelete: ReferentialAction.Restrict);
    }
  }
}
