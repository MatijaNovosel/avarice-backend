using Microsoft.EntityFrameworkCore.Migrations;

namespace avarice_backend.Migrations
{
  public partial class NewCategoriesFix : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 5L);

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 33L,
          column: "icon",
          value: "mdi-car");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 40L,
          column: "icon",
          value: "mdi-cup");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 44L,
          column: "icon",
          value: "mdi-drama-masks");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 64L,
          column: "icon",
          value: "mdi-cards");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 67L,
          column: "icon",
          value: "mdi-image");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 73L,
          column: "icon",
          value: "mdi-newspaper");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 79L,
          column: "icon",
          value: "mdi-hand-back-left");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 82L,
          column: "icon",
          value: "mdi-home");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 84L,
          column: "icon",
          value: "mdi-currency-usd");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 33L,
          column: "icon",
          value: "mdi-hand-coin");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 40L,
          column: "icon",
          value: "mdi-liquor");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 44L,
          column: "icon",
          value: "mdi-hand-clap");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 64L,
          column: "icon",
          value: "mdi-card-multiple");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 67L,
          column: "icon",
          value: "mdi-view-gallery");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 73L,
          column: "icon",
          value: "mdi-newspaper-check");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 79L,
          column: "icon",
          value: "mdi-hand-extended");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 82L,
          column: "icon",
          value: "mdi-house");

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 84L,
          column: "icon",
          value: "mdi-hand-coin");

      migrationBuilder.InsertData(
          table: "category",
          columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
          values: new object[] { 5L, "#ffffff", "mdi-glass-cocktail", "Bar, cafe", 2L, "ee103364-7617-4474-889e-320838e5f3a5" });
    }
  }
}
