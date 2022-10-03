using avarice_backend.Models;
using System.Collections.Generic;

namespace avarice_backend.Utils
{
  public static class PresetCategories
  {
    public static List<Category> Categories = new List<Category>() {
      // Food & drinks
      new Category()
      {
        Icon = "mdi-food-fork-drink",
        Name = "Food & Drinks"
      },
      new Category()
      {
        Icon = "mdi-food",
        Name = "Restaurant, fast-food",
        ParentId = 2
      },
      new Category()
      {
        Icon = "mdi-glass-cocktail",
        Name = "Bar, cafe",
        ParentId = 2
      },
      new Category()
      {
        Icon = "mdi-cart",
        Name = "Groceries",
        ParentId = 2
      },
      // Shopping
      new Category()
      {
        Icon = "mdi-basket",
        Name = "Shopping"
      },
      new Category()
      {
        Icon = "mdi-tshirt-crew",
        Name = "Clothes and shoes",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-pill",
        Name = "Drug-store, chemist",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-laptop",
        Name = "Electronics, accessories",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-emoticon",
        Name = "Free time",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-gift",
        Name = "Gifts, joy",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-bottle-tonic-plus",
        Name = "Health and beauty",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-home",
        Name = "Home, garden",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-diamond-stone",
        Name = "Jewels, accessories",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-baby-carriage",
        Name = "Kids",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-paw",
        Name = "Pets, animals",
        ParentId = 7
      },
      new Category()
      {
        Icon = "mdi-hammer-screwdriver",
        Name = "Stationery, tools",
        ParentId = 7
      },
      // Housing
      new Category()
      {
        Icon = "mdi-home",
        Name = "Housing"
      },
      new Category()
      {
        Icon = "mdi-lightbulb",
        Name = "Energy, utilities",
        ParentId = 20
      },
      new Category()
      {
        Icon = "mdi-hammer",
        Name = "Maintenance, repairs",
        ParentId = 20
      },
      new Category()
      {
        Icon = "mdi-bank-plus",
        Name = "Mortgage",
        ParentId = 20
      },
      new Category()
      {
        Icon = "mdi-shield-home",
        Name = "Property insurance",
        ParentId = 20
      },
      new Category()
      {
        Icon = "mdi-key-variant",
        Name = "Rent",
        ParentId = 20
      },
      new Category()
      {
        Icon = "mdi-home-circle-outline",
        Name = "Services",
        ParentId = 20
      },
      // Transportation
      new Category()
      {
        Icon = "mdi-bus",
        Name = "Transportation"
      },
      new Category()
      {
        Icon = "mdi-bag-suitcase",
        Name = "Business trips",
        ParentId = 26
      },
      new Category()
      {
        Icon = "mdi-airplane",
        Name = "Long distance",
        ParentId = 26
      },
      new Category()
      {
        Icon = "mdi-tram",
        Name = "Public transport",
        ParentId = 26
      },
      new Category()
      {
        Icon = "mdi-taxi",
        Name = "Taxi",
        ParentId = 26
      },
      // Vehicle
      new Category()
      {
        Icon = "mdi-car",
        Name = "Vehicle"
      },
      new Category()
      {
        Icon = "mdi-fuel",
        Name = "Fuel",
        ParentId = 31
      },
      new Category()
      {
        Icon = "mdi-car",
        Name = "Leasing",
        ParentId = 31
      },
      new Category()
      {
        Icon = "mdi-parking",
        Name = "Parking",
        ParentId = 31
      },
      new Category()
      {
        Icon = "mdi-key",
        Name = "Rentals",
        ParentId = 31
      },
      new Category()
      {
        Icon = "mdi-shield-car",
        Name = "Vehicle insurance",
        ParentId = 31
      },
      new Category()
      {
        Icon = "mdi-tools",
        Name = "Vehicle maintenance",
        ParentId = 31
      },
      // Life & Entertainment
      new Category()
      {
        Icon = "mdi-account",
        Name = "Life & Entertainment"
      },
      new Category()
      {
        Icon = "mdi-dumbbell",
        Name = "Active sport, fitness",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-cup",
        Name = "Alcohol, tobacco",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-book-open-variant",
        Name = "Books, audio, subscriptions",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-gift",
        Name = "Charity, gifts",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-drama-masks",
        Name = "Culture, sports events",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-school",
        Name = "Education, development",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-doctor",
        Name = "Health care, doctor",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-heart",
        Name = "Hobbies",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-palm-tree",
        Name = "Holiday, trips, hotels",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-cake",
        Name = "Life events",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-dice-5",
        Name = "Lottery, gambling",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-television-classic",
        Name = "TV, Streaming",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-flower",
        Name = "Wellness, beauty",
        ParentId = 38
      },
      new Category()
      {
        Icon = "mdi-basketball",
        Name = "Culture, sport events",
        ParentId = 38
      },
      // Communication, PC
      new Category()
      {
        Icon = "mdi-laptop",
        Name = "Communication, PC"
      },
      new Category()
      {
        Icon = "mdi-wifi",
        Name = "Internet",
        ParentId = 54
      },
      new Category()
      {
        Icon = "mdi-phone",
        Name = "Phone, cell phone",
        ParentId = 54
      },
      new Category()
      {
        Icon = "mdi-email",
        Name = "Postal services",
        ParentId = 54
      },
      new Category()
      {
        Icon = "mdi-controller-classic",
        Name = "Software, apps, games",
        ParentId = 54
      },
      new Category()
      {
        Icon = "mdi-controller-classic",
        Name = "Games",
        ParentId = 54
      },
      // Financial expenses
      new Category()
      {
        Icon = "mdi-currency-usd",
        Name = "Financial expenses"
      },
      new Category()
      {
        Icon = "mdi-account-alert",
        Name = "Advisory",
        ParentId = 60
      },
      new Category()
      {
        Icon = "mdi-comment-remove",
        Name = "Charges, Fees",
        ParentId = 60
      },
      new Category()
      {
        Icon = "mdi-account-child",
        Name = "Child Support",
        ParentId = 60
      },
      new Category()
      {
        Icon = "mdi-alert-circle",
        Name = "Fines",
        ParentId = 60
      },
      new Category()
      {
        Icon = "mdi-card-bulleted",
        Name = "Insurances",
        ParentId = 60
      },
      new Category()
      {
        Icon = "mdi-cards",
        Name = "Loan, interests",
        ParentId = 60
      },
      new Category()
      {
        Icon = "mdi-content-cut",
        Name = "Taxes",
        ParentId = 60
      },
      // Investments
      new Category()
      {
        Icon = "mdi-chart-line",
        Name = "Investments"
      },
      new Category()
      {
        Icon = "mdi-image",
        Name = "Collections",
        ParentId = 68
      },
      new Category()
      {
        Icon = "mdi-chart-multiple",
        Name = "Financial investments",
        ParentId = 68
      },
      new Category()
      {
        Icon = "mdi-domain",
        Name = "Realty",
        ParentId = 68
      },
      new Category()
      {
        Icon = "mdi-account-cash",
        Name = "Savings",
        ParentId = 68
      },
      new Category()
      {
        Icon = "mdi-car",
        Name = "Vehicles, chattels",
        ParentId = 68
      },
      // Income
      new Category()
      {
        Icon = "mdi-currency-usd",
        Name = "Income"
      },
      new Category()
      {
        Icon = "mdi-newspaper",
        Name = "Checks, coupons",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-account-child",
        Name = "Child Support",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-check-decagram",
        Name = "Dues & grants",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-gift",
        Name = "Gifts",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-ticket-percent",
        Name = "Interests, dividends",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-currency-usd",
        Name = "Lending, renting",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-dice-5",
        Name = "Lottery, gambling",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-undo",
        Name = "Refunds (tax, purchase)",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-home",
        Name = "Rental income",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-sale",
        Name = "Sale",
        ParentId = 74
      },
      new Category()
      {
        Icon = "mdi-currency-usd",
        Name = "Wage, invoices",
        ParentId = 74
      },
      // Others
      new Category()
      {
        Icon = "mdi-account-question",
        Name = "Others"
      },
      new Category()
      {
        Icon = "mdi-help-circle",
        Name = "Missing",
        ParentId = 85
      }
    };
  }
}