using Microsoft.EntityFrameworkCore.Migrations;

namespace fin_app_backend.Migrations
{
    public partial class AddedBalanceToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "balance",
                table: "account",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "balance",
                table: "account");
        }
    }
}
