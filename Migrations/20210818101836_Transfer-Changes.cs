using Microsoft.EntityFrameworkCore.Migrations;

namespace avarice_backend.Migrations
{
  public partial class TransferChanges : Migration
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
          name: "transaction_ibfk_3",
          table: "transaction");

      migrationBuilder.AddColumn<int>(
          name: "TransferAccountId1",
          table: "transaction",
          type: "int(11)",
          nullable: true);

      migrationBuilder.AddColumn<int>(
          name: "transferAccountId",
          table: "transaction",
          type: "int(11)",
          nullable: true);

      migrationBuilder.InsertData(
          table: "account",
          columns: new[] { "id", "balance", "currency", "name", "userId" },
          values: new object[] { 2, 200.0, "EUR", "Euros", "ee103364-7617-4474-889e-320838e5f3a5" });

      migrationBuilder.CreateIndex(
          name: "IX_transaction_transferAccountId",
          table: "transaction",
          column: "transferAccountId");

      migrationBuilder.CreateIndex(
          name: "IX_transaction_TransferAccountId1",
          table: "transaction",
          column: "TransferAccountId1");

      migrationBuilder.AddForeignKey(
          name: "FK_transaction_account_TransferAccountId1",
          table: "transaction",
          column: "TransferAccountId1",
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
          name: "transaction_ibfk_3",
          table: "transaction",
          column: "userId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_4",
          table: "transaction",
          column: "categoryId",
          principalTable: "category",
          principalColumn: "id",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_transaction_account_TransferAccountId1",
          table: "transaction");

      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_2",
          table: "transaction");

      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_3",
          table: "transaction");

      migrationBuilder.DropForeignKey(
          name: "transaction_ibfk_4",
          table: "transaction");

      migrationBuilder.DropIndex(
          name: "IX_transaction_transferAccountId",
          table: "transaction");

      migrationBuilder.DropIndex(
          name: "IX_transaction_TransferAccountId1",
          table: "transaction");

      migrationBuilder.DeleteData(
          table: "account",
          keyColumn: "id",
          keyValue: 2);

      migrationBuilder.DropColumn(
          name: "TransferAccountId1",
          table: "transaction");

      migrationBuilder.DropColumn(
          name: "transferAccountId",
          table: "transaction");

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_1",
          table: "transaction",
          column: "userId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_2",
          table: "transaction",
          column: "accountId",
          principalTable: "account",
          principalColumn: "id",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "transaction_ibfk_3",
          table: "transaction",
          column: "categoryId",
          principalTable: "category",
          principalColumn: "id",
          onDelete: ReferentialAction.Restrict);
    }
  }
}
