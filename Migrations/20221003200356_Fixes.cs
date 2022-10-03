using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace avarice_backend.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 87L);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-basket", "Shopping", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 7L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-tshirt-crew", "Clothes and shoes", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 8L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-pill", "Drug-store, chemist", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 9L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-laptop", "Electronics, accessories", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 10L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-emoticon", "Free time", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 11L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-gift", "Gifts, joy", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 12L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-bottle-tonic-plus", "Health and beauty", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 13L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-home", "Home, garden", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 14L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-diamond-stone", "Jewels, accessories", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 15L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-baby-carriage", "Kids", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 16L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-paw", "Pets, animals", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 17L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-hammer-screwdriver", "Stationery, tools", 6L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 18L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-home", "Housing", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 19L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-lightbulb", "Energy, utilities", 18L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 20L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-hammer", "Maintenance, repairs", 18L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 21L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-bank-plus", "Mortgage", 18L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 22L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-shield-home", "Property insurance", 18L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 23L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-key-variant", "Rent", 18L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 24L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-home-circle-outline", "Services", 18L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 25L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-bus", "Transportation", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 26L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-bag-suitcase", "Business trips", 25L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 27L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-airplane", "Long distance", 25L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 28L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-tram", "Public transport", 25L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 29L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-taxi", "Taxi", 25L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 30L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-car", "Vehicle", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 31L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-fuel", "Fuel", 30L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 32L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-car", "Leasing", 30L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 33L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-parking", "Parking", 30L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 34L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-key", "Rentals", 30L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 35L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-shield-car", "Vehicle insurance", 30L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 36L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-tools", "Vehicle maintenance", 30L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 37L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account", "Life & Entertainment", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 38L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-dumbbell", "Active sport, fitness", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 39L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-cup", "Alcohol, tobacco", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 40L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-book-open-variant", "Books, audio, subscriptions", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 41L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-gift", "Charity, gifts", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 43L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-school", "Education, development", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 44L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-doctor", "Health care, doctor", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 45L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-heart", "Hobbies", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 46L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-palm-tree", "Holiday, trips, hotels", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 47L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-cake", "Life events", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 48L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-dice-5", "Lottery, gambling", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 49L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-television-classic", "TV, Streaming", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 50L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-flower", "Wellness, beauty", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 51L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-basketball", "Culture, sport events", 37L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 52L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-laptop", "Communication, PC", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 53L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-wifi", "Internet", 52L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 54L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-phone", "Phone, cell phone", 52L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 55L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-email", "Postal services", 52L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 56L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-controller-classic", "Software, apps, games", 52L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 57L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-controller-classic", "Games", 52L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 58L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-currency-usd", "Financial expenses", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 59L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-alert", "Advisory", 58L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 60L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-comment-remove", "Charges, Fees", 58L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 61L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-child", "Child Support", 58L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 62L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-alert-circle", "Fines", 58L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 63L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-card-bulleted", "Insurances", 58L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 64L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-cards", "Loan, interests", 58L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 65L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-content-cut", "Taxes", 58L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 66L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-chart-line", "Investments", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 67L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-image", "Collections", 66L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 68L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-chart-multiple", "Financial investments", 66L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 69L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-domain", "Realty", 66L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 70L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-cash", "Savings", 66L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 71L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-car", "Vehicles, chattels", 66L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 72L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-currency-usd", "Income", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 73L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-newspaper", "Checks, coupons", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 74L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-child", "Child Support", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 75L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-check-decagram", "Dues & grants", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 76L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-gift", "Gifts", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 77L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-ticket-percent", "Interests, dividends", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 78L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-currency-usd", "Lending, renting", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 79L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-dice-5", "Lottery, gambling", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 80L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-undo", "Refunds (tax, purchase)", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 81L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-home", "Rental income", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 82L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-sale", "Sale", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 83L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-currency-usd", "Wage, invoices", 72L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 84L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-question", "Others", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 85L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-help-circle", "Missing", 84L });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "parentId", "userId" },
                values: new object[,]
                {
                    { 5L, "#ffffff", "mdi-cart", "Groceries", 2L, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 42L, "#ffffff", "mdi-drama-masks", "Culture, sports events", 37L, "b2beece6-28da-4c7f-b304-3a526d166f00" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 42L);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-cart", "Groceries", 2L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 7L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-basket", "Shopping", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 8L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-tshirt-crew", "Clothes and shoes", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 9L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-pill", "Drug-store, chemist", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 10L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-laptop", "Electronics, accessories", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 11L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-emoticon", "Free time", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 12L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-gift", "Gifts, joy", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 13L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-bottle-tonic-plus", "Health and beauty", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 14L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-home", "Home, garden", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 15L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-diamond-stone", "Jewels, accessories", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 16L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-baby-carriage", "Kids", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 17L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-paw", "Pets, animals", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 18L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-hammer-screwdriver", "Stationery, tools", 7L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 19L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-home", "Housing", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 20L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-lightbulb", "Energy, utilities", 20L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 21L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-hammer", "Maintenance, repairs", 20L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 22L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-bank-plus", "Mortgage", 20L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 23L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-shield-home", "Property insurance", 20L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 24L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-key-variant", "Rent", 20L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 25L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-home-circle-outline", "Services", 20L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 26L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-bus", "Transportation", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 27L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-bag-suitcase", "Business trips", 26L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 28L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-airplane", "Long distance", 26L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 29L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-tram", "Public transport", 26L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 30L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-taxi", "Taxi", 26L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 31L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-car", "Vehicle", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 32L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-fuel", "Fuel", 31L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 33L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-car", "Leasing", 31L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 34L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-parking", "Parking", 31L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 35L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-key", "Rentals", 31L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 36L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-shield-car", "Vehicle insurance", 31L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 37L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-tools", "Vehicle maintenance", 31L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 38L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account", "Life & Entertainment", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 39L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-dumbbell", "Active sport, fitness", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 40L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-cup", "Alcohol, tobacco", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 41L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-book-open-variant", "Books, audio, subscriptions", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 43L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-gift", "Charity, gifts", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 44L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-drama-masks", "Culture, sports events", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 45L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-school", "Education, development", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 46L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-doctor", "Health care, doctor", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 47L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-heart", "Hobbies", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 48L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-palm-tree", "Holiday, trips, hotels", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 49L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-cake", "Life events", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 50L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-dice-5", "Lottery, gambling", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 51L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-television-classic", "TV, Streaming", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 52L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-flower", "Wellness, beauty", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 53L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-basketball", "Culture, sport events", 38L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 54L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-laptop", "Communication, PC", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 55L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-wifi", "Internet", 54L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 56L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-phone", "Phone, cell phone", 54L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 57L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-email", "Postal services", 54L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 58L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-controller-classic", "Software, apps, games", 54L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 59L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-controller-classic", "Games", 54L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 60L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-currency-usd", "Financial expenses", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 61L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-alert", "Advisory", 60L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 62L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-comment-remove", "Charges, Fees", 60L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 63L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-child", "Child Support", 60L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 64L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-alert-circle", "Fines", 60L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 65L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-card-bulleted", "Insurances", 60L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 66L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-cards", "Loan, interests", 60L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 67L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-content-cut", "Taxes", 60L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 68L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-chart-line", "Investments", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 69L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-image", "Collections", 68L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 70L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-chart-multiple", "Financial investments", 68L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 71L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-domain", "Realty", 68L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 72L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-cash", "Savings", 68L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 73L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-car", "Vehicles, chattels", 68L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 74L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-currency-usd", "Income", null });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 75L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-newspaper", "Checks, coupons", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 76L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-account-child", "Child Support", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 77L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-check-decagram", "Dues & grants", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 78L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-gift", "Gifts", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 79L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-ticket-percent", "Interests, dividends", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 80L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-currency-usd", "Lending, renting", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 81L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-dice-5", "Lottery, gambling", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 82L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-undo", "Refunds (tax, purchase)", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 83L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-home", "Rental income", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 84L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-sale", "Sale", 74L });

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: 85L,
                columns: new[] { "icon", "name", "parentId" },
                values: new object[] { "mdi-currency-usd", "Wage, invoices", 74L });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "color", "icon", "name", "parentId", "system", "userId" },
                values: new object[,]
                {
                    { 86L, "#ffffff", "mdi-account-question", "Others", null, 0ul, "b2beece6-28da-4c7f-b304-3a526d166f00" },
                    { 87L, "#ffffff", "mdi-help-circle", "Missing", 85L, 0ul, "b2beece6-28da-4c7f-b304-3a526d166f00" }
                });
        }
    }
}
