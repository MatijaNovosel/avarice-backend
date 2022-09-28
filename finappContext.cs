using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

#nullable disable

namespace avarice_backend
{
  public partial class avariceContext : IdentityDbContext<User>
  {
    public IConfiguration Configuration { get; }

    public avariceContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public avariceContext(DbContextOptions<avariceContext> options, IConfiguration configuration) : base(options)
    {
      Configuration = configuration;
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Template> Templates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseMySql(Configuration["ConnectionString"], Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.32-mysql"));
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.HasCharSet("latin1");

      modelBuilder.Entity<Account>(entity =>
      {
        entity.ToTable("account");

        entity.HasCharSet("latin1")
          .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.UserId, "userId");

        entity.Property(e => e.Balance).HasColumnName("balance");

        entity.Property(e => e.Id)
          .HasColumnType("bigint")
          .HasColumnName("id")
          .ValueGeneratedOnAdd();

        entity.Property(e => e.Currency)
          .IsRequired()
          .HasMaxLength(32)
          .HasColumnName("currency")
          .HasDefaultValueSql("'HRK'");

        entity.Property(e => e.Name)
          .HasMaxLength(64)
          .HasColumnName("name");

        entity.Property(e => e.UserId)
          .HasColumnName("userId");

        entity.HasOne(d => d.User)
          .WithMany(p => p.Accounts)
          .HasForeignKey(d => d.UserId)
          .HasConstraintName("account_ibfk_1");
      });

      modelBuilder.Entity<Transaction>(entity =>
      {
        entity.ToTable("transaction");

        entity.HasCharSet("latin1")
          .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.AccountId, "accountId");

        entity.HasIndex(e => e.UserId, "userId");

        entity.HasIndex(e => e.CategoryId, "categoryId");

        entity.Property(e => e.Id)
          .HasColumnType("bigint")
          .HasColumnName("id")
          .ValueGeneratedOnAdd();

        entity.Property(e => e.AccountId)
          .HasColumnType("bigint")
          .HasColumnName("accountId");

        entity.Property(e => e.TransferAccountId)
          .HasColumnType("bigint")
          .HasColumnName("transferAccountId");

        entity.Property(e => e.CategoryId)
          .HasColumnType("bigint")
          .HasColumnName("categoryId");

        entity.Property(e => e.Amount).HasColumnName("amount");

        entity.Property(e => e.Description)
          .HasMaxLength(255)
          .HasColumnName("description");

        entity.Property(e => e.TransactionType)
          .HasMaxLength(3)
          .HasColumnName("transactionType");

        entity.Property(e => e.UserId)
          .HasColumnName("userId");

        entity.HasOne(d => d.Account)
          .WithMany(p => p.Transactions)
          .HasForeignKey(d => d.AccountId)
          .HasConstraintName("transaction_ibfk_1");

        entity.HasOne(d => d.TransferAccount)
          .WithMany(p => p.TransferTransactions)
          .HasForeignKey(d => d.TransferAccountId)
          .HasConstraintName("transaction_ibfk_2");

        entity.HasOne(d => d.User)
          .WithMany(p => p.Transactions)
          .HasForeignKey(d => d.UserId)
          .HasConstraintName("transaction_ibfk_3");

        entity.HasOne(d => d.Category)
          .WithMany(p => p.Transactions)
          .HasForeignKey(d => d.CategoryId)
          .HasConstraintName("transaction_ibfk_4");
      });

      modelBuilder.Entity<Template>(entity =>
      {
        entity.ToTable("template");

        entity.HasCharSet("latin1")
          .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.AccountId, "accountId");

        entity.HasIndex(e => e.UserId, "userId");

        entity.HasIndex(e => e.CategoryId, "categoryId");

        entity.Property(e => e.Id)
          .HasColumnType("bigint")
          .HasColumnName("id")
          .ValueGeneratedOnAdd();

        entity.Property(e => e.AccountId)
          .HasColumnType("bigint")
          .HasColumnName("accountId");

        entity.Property(e => e.TransferAccountId)
          .HasColumnType("bigint")
          .HasColumnName("transferAccountId");

        entity.Property(e => e.CategoryId)
          .HasColumnType("bigint")
          .HasColumnName("categoryId");

        entity.Property(e => e.Amount).HasColumnName("amount");

        entity.Property(e => e.Description)
          .HasMaxLength(255)
          .HasColumnName("description");

        entity.Property(e => e.TransactionType)
          .HasMaxLength(3)
          .HasColumnName("transactionType");

        entity.Property(e => e.UserId)
          .HasColumnName("userId");

        entity.HasOne(d => d.Account)
          .WithMany(p => p.Templates)
          .HasForeignKey(d => d.AccountId)
          .HasConstraintName("template_ibfk_1");

        entity.HasOne(d => d.TransferAccount)
          .WithMany(p => p.TransferTemplates)
          .HasForeignKey(d => d.TransferAccountId)
          .HasConstraintName("template_ibfk_2");

        entity.HasOne(d => d.User)
          .WithMany(p => p.Templates)
          .HasForeignKey(d => d.UserId)
          .HasConstraintName("template_ibfk_3");

        entity.HasOne(d => d.Category)
          .WithMany(p => p.Templates)
          .HasForeignKey(d => d.CategoryId)
          .HasConstraintName("template_ibfk_4");
      });

      modelBuilder.Entity<Category>(entity =>
      {
        entity.ToTable("category");

        entity.HasCharSet("latin1")
          .UseCollation("latin1_swedish_ci");

        entity.Property(e => e.Id)
          .HasColumnType("bigint")
          .HasColumnName("id")
          .ValueGeneratedOnAdd();

        entity.Property(e => e.UserId)
          .HasColumnName("userId");

        entity.Property(e => e.ParentId)
          .HasColumnName("parentId");

        entity.Property(e => e.Name)
          .HasMaxLength(32)
          .HasColumnName("name");

        entity.Property(e => e.System)
          .HasColumnType("bit")
          .HasColumnName("system")
          .HasDefaultValue(false);

        entity.Property(e => e.Icon)
          .HasMaxLength(32)
          .HasColumnName("icon");

        entity.Property(e => e.Color)
          .HasMaxLength(32)
          .HasColumnName("color");

        entity.HasOne(d => d.User)
          .WithMany(p => p.Categories)
          .HasForeignKey(d => d.UserId)
          .HasConstraintName("category_ibfk_1");

        entity.HasMany(j => j.SubCategories)
          .WithOne(j => j.Parent)
          .HasForeignKey(j => j.ParentId)
          .HasConstraintName("category_ibfk_2");
      });

      modelBuilder.Entity<User>().HasData(new User
      {
        Id = "ee103364-7617-4474-889e-320838e5f3a5",
        UserName = "Novosel",
        Email = "mnovosel5@gmail.com",
        NormalizedEmail = "MNOVOSEL5@GMAIL.COM",
        EmailConfirmed = false,
        PasswordHash = "AQAAAAEAACcQAAAAEM0Wt1TEKVt7yHabPEkIPjgI1nmxtwcdhGuteBZVD1DSoSRSPans/Q+LChfIteJucw==",
        SecurityStamp = "KQLSA5W3M75PPLZ34LBVUTTSVTMJ7ANN",
        ConcurrencyStamp = "89704630-4abf-4488-9cbd-4f9ec29fcb8b"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 1,
        Name = "Gyro",
        Balance = 14000,
        Currency = "HRK",
        UserId = "ee103364-7617-4474-889e-320838e5f3a5"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 2,
        Name = "Euros",
        Balance = 200,
        Currency = "EUR",
        UserId = "ee103364-7617-4474-889e-320838e5f3a5"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 3,
        Name = "Checking",
        Balance = 0,
        Currency = "HRK",
        UserId = "ee103364-7617-4474-889e-320838e5f3a5"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 4,
        Name = "Pocket",
        Balance = 800,
        Currency = "HRK",
        UserId = "ee103364-7617-4474-889e-320838e5f3a5"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 1,
        UserId = null,
        Color = "grey",
        Icon = "mdi-swap-horizontal",
        Name = "Transfer",
        System = true
      });

      // Food & drinks

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 2,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-food-fork-drink",
        Name = "Food & Drinks"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 3,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-food",
        Name = "Restaurant, fast-food",
        ParentId = 2
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 4,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-glass-cocktail",
        Name = "Bar, cafe",
        ParentId = 2
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 6,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-cart",
        Name = "Groceries",
        ParentId = 2
      });

      // Shopping

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 7,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-basket",
        Name = "Shopping"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 8,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-tshirt-crew",
        Name = "Clothes and shoes",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 9,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-pill",
        Name = "Drug-store, chemist",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 10,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-laptop",
        Name = "Electronics, accessories",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 11,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-emoticon",
        Name = "Free time",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 12,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-gift",
        Name = "Gifts, joy",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 13,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-bottle-tonic-plus",
        Name = "Health and beauty",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 14,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-home",
        Name = "Home, garden",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 15,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-diamond-stone",
        Name = "Jewels, accessories",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 16,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-baby-carriage",
        Name = "Kids",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 17,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-paw",
        Name = "Pets, animals",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 18,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-hammer-screwdriver",
        Name = "Stationery, tools",
        ParentId = 7
      });

      // Housing 

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 19,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-home",
        Name = "Housing"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 20,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-lightbulb",
        Name = "Energy, utilities",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 21,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-hammer",
        Name = "Maintenance, repairs",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 22,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-bank-plus",
        Name = "Mortgage",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 23,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-shield-home",
        Name = "Property insurance",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 24,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-key-variant",
        Name = "Rent",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 25,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-home-circle-outline",
        Name = "Services",
        ParentId = 20
      });

      // Transportation

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 26,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-bus",
        Name = "Transportation"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 27,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-bag-suitcase",
        Name = "Business trips",
        ParentId = 26
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 28,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-airplane",
        Name = "Long distance",
        ParentId = 26
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 29,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-tram",
        Name = "Public transport",
        ParentId = 26
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 30,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-taxi",
        Name = "Taxi",
        ParentId = 26
      });

      // Vehicle

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 31,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-car",
        Name = "Vehicle"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 32,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-fuel",
        Name = "Fuel",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 33,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-car",
        Name = "Leasing",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 34,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-parking",
        Name = "Parking",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 35,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-key",
        Name = "Rentals",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 36,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-shield-car",
        Name = "Vehicle insurance",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 37,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-tools",
        Name = "Vehicle maintenance",
        ParentId = 31
      });

      // Life & Entertainment

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 38,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-account",
        Name = "Life & Entertainment"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 39,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-dumbbell",
        Name = "Active sport, fitness",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 40,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-cup",
        Name = "Alcohol, tobacco",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 41,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-book-open-variant",
        Name = "Books, audio, subscriptions",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 43,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-gift",
        Name = "Charity, gifts",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 44,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-drama-masks",
        Name = "Culture, sports events",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 45,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-school",
        Name = "Education, development",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 46,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-doctor",
        Name = "Health care, doctor",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 47,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-heart",
        Name = "Hobbies",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 48,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-palm-tree",
        Name = "Holiday, trips, hotels",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 49,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-cake",
        Name = "Life events",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 50,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-dice-5",
        Name = "Lottery, gambling",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 51,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-television-classic",
        Name = "TV, Streaming",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 52,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-flower",
        Name = "Wellness, beauty",
        ParentId = 38
      });

      // Communication, PC

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 53,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-laptop",
        Name = "Communication, PC"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 54,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-wifi",
        Name = "Internet",
        ParentId = 53
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 55,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-phone",
        Name = "Phone, cell phone",
        ParentId = 53
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 56,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-email",
        Name = "Postal services",
        ParentId = 53
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 57,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-controller-classic",
        Name = "Software, apps, games",
        ParentId = 53
      });

      // Financial expenses

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 58,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-currency-usd",
        Name = "Financial expenses"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 59,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-account-alert",
        Name = "Advisory",
        ParentId = 58
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 60,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-comment-remove",
        Name = "Charges, Fees",
        ParentId = 58
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 61,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-account-child",
        Name = "Child Support",
        ParentId = 58
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 62,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-alert-circle",
        Name = "Fines",
        ParentId = 58
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 63,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-card-bulleted",
        Name = "Insurances",
        ParentId = 58
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 64,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-cards",
        Name = "Loan, interests",
        ParentId = 58
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 65,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-content-cut",
        Name = "Taxes",
        ParentId = 58
      });

      // Investments

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 66,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-chart-line",
        Name = "Investments"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 67,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-image",
        Name = "Collections",
        ParentId = 66
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 68,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-chart-multiple",
        Name = "Financial investments",
        ParentId = 66
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 69,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-domain",
        Name = "Realty",
        ParentId = 66
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 70,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-account-cash",
        Name = "Savings",
        ParentId = 66
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 71,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-car",
        Name = "Vehicles, chattels",
        ParentId = 66
      });

      // Income

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 72,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-currency-usd",
        Name = "Income"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 73,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-newspaper",
        Name = "Checks, coupons",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 74,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-account-child",
        Name = "Child Support",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 75,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-check-decagram",
        Name = "Dues & grants",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 76,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-gift",
        Name = "Gifts",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 78,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-ticket-percent",
        Name = "Interests, dividends",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 79,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-currency-usd",
        Name = "Lending, renting",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 80,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-dice-5",
        Name = "Lottery, gambling",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 81,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-undo",
        Name = "Refunds (tax, purchase)",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 82,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-home",
        Name = "Rental income",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 83,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-sale",
        Name = "Sale",
        ParentId = 72
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 84,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-currency-usd",
        Name = "Wage, invoices",
        ParentId = 72
      });

      // Others

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 85,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-account-question",
        Name = "Others"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 86,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-help-circle",
        Name = "Missing",
        ParentId = 85
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
