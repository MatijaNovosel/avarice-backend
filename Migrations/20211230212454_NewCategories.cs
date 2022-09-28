using Microsoft.EntityFrameworkCore.Migrations;

namespace avarice_backend.Migrations
{
  public partial class NewCategories : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "category",
          columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
          values: new object[,]
          {
                    { 19L, "#ffffff", "mdi-home", "Housing", null, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 20L, "#ffffff", "mdi-lightbulb", "Energy, utilities", 20L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 26L, "#ffffff", "mdi-bus", "Transportation", null, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 31L, "#ffffff", "mdi-car", "Vehicle", null, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 38L, "#ffffff", "mdi-account", "Life & Entertainment", null, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 53L, "#ffffff", "mdi-laptop", "Communication, PC", null, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 58L, "#ffffff", "mdi-currency-usd", "Financial expenses", null, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 66L, "#ffffff", "mdi-chart-line", "Investments", null, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 72L, "#ffffff", "mdi-currency-usd", "Income", null, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 85L, "#ffffff", "mdi-account-question", "Others", null, "ee103364-7617-4474-889e-320838e5f3a5" }
          });

      migrationBuilder.InsertData(
          table: "category",
          columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
          values: new object[,]
          {
                    { 21L, "#ffffff", "mdi-hammer", "Maintenance, repairs", 20L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 56L, "#ffffff", "mdi-email", "Postal services", 53L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 57L, "#ffffff", "mdi-controller-classic", "Software, apps, games", 53L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 59L, "#ffffff", "mdi-account-alert", "Advisory", 58L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 60L, "#ffffff", "mdi-comment-remove", "Charges, Fees", 58L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 61L, "#ffffff", "mdi-account-child", "Child Support", 58L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 62L, "#ffffff", "mdi-alert-circle", "Fines", 58L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 63L, "#ffffff", "mdi-card-bulleted", "Insurances", 58L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 64L, "#ffffff", "mdi-card-multiple", "Loan, interests", 58L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 65L, "#ffffff", "mdi-content-cut", "Taxes", 58L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 67L, "#ffffff", "mdi-view-gallery", "Collections", 66L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 68L, "#ffffff", "mdi-chart-multiple", "Financial investments", 66L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 69L, "#ffffff", "mdi-domain", "Realty", 66L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 70L, "#ffffff", "mdi-account-cash", "Savings", 66L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 71L, "#ffffff", "mdi-car", "Vehicles, chattels", 66L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 73L, "#ffffff", "mdi-newspaper-check", "Checks, coupons", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 74L, "#ffffff", "mdi-account-child", "Child Support", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 75L, "#ffffff", "mdi-check-decagram", "Dues & grants", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 76L, "#ffffff", "mdi-gift", "Gifts", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 77L, "#ffffff", "mdi-ticket-percent", "Interests, dividends", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 78L, "#ffffff", "mdi-ticket-percent", "Interests, dividends", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 79L, "#ffffff", "mdi-hand-extended", "Lending, renting", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 80L, "#ffffff", "mdi-dice-5", "Lottery, gambling", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 81L, "#ffffff", "mdi-undo", "Refunds (tax, purchase)", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 82L, "#ffffff", "mdi-house", "Rental income", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 83L, "#ffffff", "mdi-sale", "Sale", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 55L, "#ffffff", "mdi-phone", "Phone, cell phone", 53L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 84L, "#ffffff", "mdi-hand-coin", "Wage, invoices", 72L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 54L, "#ffffff", "mdi-wifi", "Internet", 53L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 51L, "#ffffff", "mdi-television-classic", "TV, Streaming", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 22L, "#ffffff", "mdi-bank-plus", "Mortgage", 20L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 23L, "#ffffff", "mdi-shield-home", "Property insurance", 20L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 24L, "#ffffff", "mdi-key-variant", "Rent", 20L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 25L, "#ffffff", "mdi-home-circle-outline", "Services", 20L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 27L, "#ffffff", "mdi-bag-suitcase", "Business trips", 26L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 28L, "#ffffff", "mdi-airplane", "Long distance", 26L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 29L, "#ffffff", "mdi-tram", "Public transport", 26L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 30L, "#ffffff", "mdi-taxi", "Taxi", 26L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 32L, "#ffffff", "mdi-fuel", "Fuel", 31L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 33L, "#ffffff", "mdi-hand-coin", "Leasing", 31L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 34L, "#ffffff", "mdi-parking", "Parking", 31L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 35L, "#ffffff", "mdi-key", "Rentals", 31L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 36L, "#ffffff", "mdi-shield-car", "Vehicle insurance", 31L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 37L, "#ffffff", "mdi-tools", "Vehicle maintenance", 31L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 39L, "#ffffff", "mdi-dumbbell", "Active sport, fitness", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 40L, "#ffffff", "mdi-liquor", "Alcohol, tobacco", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 41L, "#ffffff", "mdi-book-open-variant", "Books, audio, subscriptions", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 43L, "#ffffff", "mdi-gift", "Charity, gifts", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 44L, "#ffffff", "mdi-hand-clap", "Culture, sports events", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 45L, "#ffffff", "mdi-school", "Education, development", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 46L, "#ffffff", "mdi-doctor", "Health care, doctor", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 47L, "#ffffff", "mdi-heart", "Hobbies", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 48L, "#ffffff", "mdi-palm-tree", "Holiday, trips, hotels", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 49L, "#ffffff", "mdi-cake", "Life events", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 50L, "#ffffff", "mdi-dice-5", "Lottery, gambling", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 52L, "#ffffff", "mdi-flower", "Wellness, beauty", 38L, "ee103364-7617-4474-889e-320838e5f3a5" },
                    { 86L, "#ffffff", "mdi-help-circle", "Missing", 85L, "ee103364-7617-4474-889e-320838e5f3a5" }
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 19L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 21L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 22L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 23L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 24L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 25L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 27L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 28L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 29L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 30L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 32L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 33L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 34L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 35L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 36L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 37L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 39L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 40L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 41L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 43L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 44L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 45L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 46L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 47L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 48L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 49L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 50L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 51L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 52L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 54L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 55L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 56L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 57L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 59L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 60L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 61L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 62L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 63L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 64L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 65L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 67L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 68L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 69L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 70L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 71L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 73L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 74L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 75L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 76L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 77L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 78L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 79L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 80L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 81L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 82L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 83L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 84L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 86L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 20L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 26L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 31L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 38L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 53L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 58L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 66L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 72L);

      migrationBuilder.DeleteData(
          table: "category",
          keyColumn: "id",
          keyValue: 85L);
    }
  }
}
