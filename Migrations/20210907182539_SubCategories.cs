using Microsoft.EntityFrameworkCore.Migrations;

namespace avarice_backend.Migrations
{
  public partial class SubCategories : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<long>(
          name: "ParentId",
          table: "category",
          type: "bigint",
          nullable: true);

      migrationBuilder.CreateIndex(
          name: "IX_category_ParentId",
          table: "category",
          column: "ParentId");

      migrationBuilder.AddForeignKey(
          name: "FK_category_category_ParentId",
          table: "category",
          column: "ParentId",
          principalTable: "category",
          principalColumn: "id",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_category_category_ParentId",
          table: "category");

      migrationBuilder.DropIndex(
          name: "IX_category_ParentId",
          table: "category");

      migrationBuilder.DropColumn(
          name: "ParentId",
          table: "category");
    }
  }
}
