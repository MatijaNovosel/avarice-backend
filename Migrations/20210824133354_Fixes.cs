using Microsoft.EntityFrameworkCore.Migrations;

namespace fin_app_backend.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_TransferAccountId1",
                table: "transaction");

            migrationBuilder.DropIndex(
                name: "IX_transaction_TransferAccountId1",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "TransferAccountId1",
                table: "transaction");

            migrationBuilder.AddForeignKey(
                name: "transaction_ibfk_1",
                table: "transaction",
                column: "accountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "transaction_ibfk_1",
                table: "transaction");

            migrationBuilder.AddColumn<int>(
                name: "TransferAccountId1",
                table: "transaction",
                type: "int(11)",
                nullable: true);

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
        }
    }
}
