using Microsoft.EntityFrameworkCore.Migrations;

namespace fin_app_backend.Migrations
{
    public partial class SystemCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "system",
                table: "category",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "color", "icon", "name", "userId" },
                values: new object[] { "grey", "mdi-swap-horizontal", "Transfer", null });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "userId" },
                values: new object[] { 2, "red", "mdi-account", "Testing category", "ee103364-7617-4474-889e-320838e5f3a5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "system",
                table: "category");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "color", "icon", "name", "userId" },
                values: new object[] { "red", "mdi-account", "Testing category", "ee103364-7617-4474-889e-320838e5f3a5" });
        }
    }
}
