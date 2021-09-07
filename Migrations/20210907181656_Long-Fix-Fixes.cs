using Microsoft.EntityFrameworkCore.Migrations;

namespace fin_app_backend.Migrations
{
    public partial class LongFixFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "transaction_ibfk_2",
                table: "transaction");

            migrationBuilder.AlterColumn<long>(
                name: "transferAccountId",
                table: "transaction",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "transaction_ibfk_2",
                table: "transaction",
                column: "transferAccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "transaction_ibfk_2",
                table: "transaction");

            migrationBuilder.AlterColumn<long>(
                name: "transferAccountId",
                table: "transaction",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "transaction_ibfk_2",
                table: "transaction",
                column: "transferAccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
