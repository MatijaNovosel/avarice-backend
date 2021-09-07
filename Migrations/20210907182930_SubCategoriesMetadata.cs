using Microsoft.EntityFrameworkCore.Migrations;

namespace fin_app_backend.Migrations
{
    public partial class SubCategoriesMetadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_category_ParentId",
                table: "category");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "category",
                newName: "parentId");

            migrationBuilder.RenameIndex(
                name: "IX_category_ParentId",
                table: "category",
                newName: "IX_category_parentId");

            migrationBuilder.AddForeignKey(
                name: "category_ibfk_2",
                table: "category",
                column: "parentId",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "category_ibfk_2",
                table: "category");

            migrationBuilder.RenameColumn(
                name: "parentId",
                table: "category",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_category_parentId",
                table: "category",
                newName: "IX_category_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_category_category_ParentId",
                table: "category",
                column: "ParentId",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
