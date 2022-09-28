using Microsoft.EntityFrameworkCore.Migrations;

namespace avarice_backend.Migrations
{
  public partial class NewCategoriesFixFix : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 77L);

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 79L,
          column: "icon",
          value: "mdi-currency-usd");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 79L,
          column: "icon",
          value: "mdi-hand-back-left");

      migrationBuilder.InsertData(
          table: "category",
          columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
          values: new object[] { 77L, "#ffffff", "mdi-ticket-percent", "Interests, dividends", 72L, "ee103364-7617-4474-889e-320838e5f3a5" });
    }
  }
}
