using Microsoft.EntityFrameworkCore.Migrations;

namespace fin_app_backend.Migrations
{
    public partial class PresetCategoriesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 19L);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 18L,
                columns: new[] { "icon", "name" },
                values: new object[] { "mdi-hammer-screwdriver", "Stationery, tools" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 18L,
                columns: new[] { "icon", "name" },
                values: new object[] { "mdi-paw", "Pets, animals" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
                values: new object[] { 19L, "#ffffff", "mdi-hammer-screwdriver", "Stationery, tools", 7L, "ee103364-7617-4474-889e-320838e5f3a5" });
        }
    }
}
