using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fin_app_backend.Migrations
{
    public partial class BIGINT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "transaction",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(18)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ee103364-7617-4474-889e-320838e5f3a5", 0, "89704630-4abf-4488-9cbd-4f9ec29fcb8b", "mnovosel5@gmail.com", false, false, null, "MNOVOSEL5@GMAIL.COM", null, "AQAAAAEAACcQAAAAEM0Wt1TEKVt7yHabPEkIPjgI1nmxtwcdhGuteBZVD1DSoSRSPans/Q+LChfIteJucw==", null, false, "KQLSA5W3M75PPLZ34LBVUTTSVTMJ7ANN", false, "Novosel" });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "id", "balance", "currency", "name", "userId" },
                values: new object[] { 1, 14000.0, "HRK", "Gyro", "ee103364-7617-4474-889e-320838e5f3a5" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "userId" },
                values: new object[] { 1, "red", "mdi-account", "Testing category", "ee103364-7617-4474-889e-320838e5f3a5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "account",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee103364-7617-4474-889e-320838e5f3a5");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "transaction",
                type: "int(18)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
