using Microsoft.EntityFrameworkCore.Migrations;

namespace avarice_backend.Migrations
{
  public partial class PresetCategories : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 2L,
          columns: new[] { "icon", "name" },
          values: new object[] { "mdi-food-fork-drink", "Food & Drinks" });

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 3L,
          columns: new[] { "icon", "name" },
          values: new object[] { "mdi-food", "Restaurant, fast-food" });

      migrationBuilder.InsertData(
          table: "category",
          columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
          values: new object[,]
          {
                    { 4L, "#ffffff", "mdi-glass-cocktail", "Bar, cafe", 2L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 5L, "#ffffff", "mdi-glass-cocktail", "Bar, cafe", 2L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 6L, "#ffffff", "mdi-cart", "Groceries", 2L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 7L, "#ffffff", "mdi-basket", "Shopping", null, "ee103364-7617-4474-889e-320838e5f3a5" }
          });

      migrationBuilder.InsertData(
          table: "category",
          columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
          values: new object[,]
          {
                    { 8L, "#ffffff", "mdi-tshirt-crew", "Clothes and shoes", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 9L, "#ffffff", "mdi-pill", "Drug-store, chemist", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 10L, "#ffffff", "mdi-laptop", "Electronics, accessories", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 11L, "#ffffff", "mdi-emoticon", "Free time", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 12L, "#ffffff", "mdi-gift", "Gifts, joy", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 13L, "#ffffff", "mdi-bottle-tonic-plus", "Health and beauty", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 14L, "#ffffff", "mdi-home", "Home, garden", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 15L, "#ffffff", "mdi-diamond-stone", "Jewels, accessories", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 16L, "#ffffff", "mdi-baby-carriage", "Kids", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 17L, "#ffffff", "mdi-paw", "Pets, animals", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 18L, "#ffffff", "mdi-paw", "Pets, animals", 7L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 19L, "#ffffff", "mdi-hammer-screwdriver", "Stationery, tools", 7L, "ee103364-7617-4474-889e-320838e5f3a5" }
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 4L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 5L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 6L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 8L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 9L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 10L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 11L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 12L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 13L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 14L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 15L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 16L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 17L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 18L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 19L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 7L);

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 2L,
          columns: new[] { "icon", "name" },
          values: new object[] { "mdi-account", "Food" });

      migrationBuilder.UpdateData(
          table: "category",
          keyColumn: "id",
          keyValue: 3L,
          columns: new[] { "icon", "name" },
          values: new object[] { "mdi-file", "Restaurant" });
    }
  }
}
