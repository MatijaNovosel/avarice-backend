using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

#nullable disable

namespace avarice_backend
{
  public partial class AvariceContext : IdentityDbContext<User>
  {
    public IConfiguration Configuration { get; }

    public AvariceContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public AvariceContext(DbContextOptions<AvariceContext> options, IConfiguration configuration) : base(options)
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

        entity.Property(e => e.CreatedAt)
          .HasColumnType("datetime")
          .HasColumnName("createdAt");

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
        Id = "b2beece6-28da-4c7f-b304-3a526d166f00",
        UserName = "matija",
        Email = "mnovosel5@gmail.com",
        NormalizedEmail = "MNOVOSEL5@GMAIL.COM",
        EmailConfirmed = true,
        PasswordHash = "AQAAAAEAACcQAAAAEHHZcifrXCQ1DciNISJi3aJgQJW+jyI+G66JPqVhhqfdn/wHXaXr8tQ0IK+F1iVJCw==",
        SecurityStamp = "M5INRPR3EKT2FOPSOKK2PJZMR4A3AKYN",
        ConcurrencyStamp = "48ad95fa-743a-4673-8927-5044d96b7717"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 1,
        Name = "Gyro",
        Balance = 14000,
        Currency = "HRK",
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 2,
        Name = "Euros",
        Balance = 200,
        Currency = "EUR",
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 3,
        Name = "Checking",
        Balance = 0,
        Currency = "HRK",
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 4,
        Name = "Pocket",
        Balance = 800,
        Currency = "HRK",
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00"
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
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-food-fork-drink",
        Name = "Food & Drinks"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 3,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-food",
        Name = "Restaurant, fast-food",
        ParentId = 2
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 4,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-glass-cocktail",
        Name = "Bar, cafe",
        ParentId = 2
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 6,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-cart",
        Name = "Groceries",
        ParentId = 2
      });

      // Shopping

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 7,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-basket",
        Name = "Shopping"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 8,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-tshirt-crew",
        Name = "Clothes and shoes",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 9,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-pill",
        Name = "Drug-store, chemist",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 10,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-laptop",
        Name = "Electronics, accessories",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 11,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-emoticon",
        Name = "Free time",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 12,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-gift",
        Name = "Gifts, joy",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 13,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-bottle-tonic-plus",
        Name = "Health and beauty",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 14,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-home",
        Name = "Home, garden",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 15,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-diamond-stone",
        Name = "Jewels, accessories",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 16,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-baby-carriage",
        Name = "Kids",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 17,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-paw",
        Name = "Pets, animals",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 18,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-hammer-screwdriver",
        Name = "Stationery, tools",
        ParentId = 7
      });

      // Housing 

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 19,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-home",
        Name = "Housing"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 20,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-lightbulb",
        Name = "Energy, utilities",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 21,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-hammer",
        Name = "Maintenance, repairs",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 22,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-bank-plus",
        Name = "Mortgage",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 23,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-shield-home",
        Name = "Property insurance",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 24,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-key-variant",
        Name = "Rent",
        ParentId = 20
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 25,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-home-circle-outline",
        Name = "Services",
        ParentId = 20
      });

      // Transportation

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 26,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-bus",
        Name = "Transportation"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 27,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-bag-suitcase",
        Name = "Business trips",
        ParentId = 26
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 28,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-airplane",
        Name = "Long distance",
        ParentId = 26
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 29,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-tram",
        Name = "Public transport",
        ParentId = 26
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 30,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-taxi",
        Name = "Taxi",
        ParentId = 26
      });

      // Vehicle

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 31,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-car",
        Name = "Vehicle"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 32,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-fuel",
        Name = "Fuel",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 33,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-car",
        Name = "Leasing",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 34,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-parking",
        Name = "Parking",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 35,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-key",
        Name = "Rentals",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 36,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-shield-car",
        Name = "Vehicle insurance",
        ParentId = 31
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 37,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-tools",
        Name = "Vehicle maintenance",
        ParentId = 31
      });

      // Life & Entertainment

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 38,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-account",
        Name = "Life & Entertainment"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 39,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-dumbbell",
        Name = "Active sport, fitness",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 40,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-cup",
        Name = "Alcohol, tobacco",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 41,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-book-open-variant",
        Name = "Books, audio, subscriptions",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 43,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-gift",
        Name = "Charity, gifts",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 44,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-drama-masks",
        Name = "Culture, sports events",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 45,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-school",
        Name = "Education, development",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 46,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-doctor",
        Name = "Health care, doctor",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 47,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-heart",
        Name = "Hobbies",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 48,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-palm-tree",
        Name = "Holiday, trips, hotels",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 49,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-cake",
        Name = "Life events",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 50,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-dice-5",
        Name = "Lottery, gambling",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 51,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-television-classic",
        Name = "TV, Streaming",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 52,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-flower",
        Name = "Wellness, beauty",
        ParentId = 38
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 53,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-basketball",
        Name = "Culture, sport events",
        ParentId = 38
      });

      // Communication, PC

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 54,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-laptop",
        Name = "Communication, PC"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 55,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-wifi",
        Name = "Internet",
        ParentId = 54
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 56,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-phone",
        Name = "Phone, cell phone",
        ParentId = 54
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 57,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-email",
        Name = "Postal services",
        ParentId = 54
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 58,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-controller-classic",
        Name = "Software, apps, games",
        ParentId = 54
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 59,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-controller-classic",
        Name = "Games",
        ParentId = 54
      });

      // Financial expenses

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 60,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-currency-usd",
        Name = "Financial expenses"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 61,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-account-alert",
        Name = "Advisory",
        ParentId = 60
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 62,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-comment-remove",
        Name = "Charges, Fees",
        ParentId = 60
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 63,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-account-child",
        Name = "Child Support",
        ParentId = 60
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 64,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-alert-circle",
        Name = "Fines",
        ParentId = 60
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 65,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-card-bulleted",
        Name = "Insurances",
        ParentId = 60
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 66,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-cards",
        Name = "Loan, interests",
        ParentId = 60
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 67,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-content-cut",
        Name = "Taxes",
        ParentId = 60
      });

      // Investments

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 68,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-chart-line",
        Name = "Investments"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 69,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-image",
        Name = "Collections",
        ParentId = 68
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 70,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-chart-multiple",
        Name = "Financial investments",
        ParentId = 68
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 71,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-domain",
        Name = "Realty",
        ParentId = 68
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 72,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-account-cash",
        Name = "Savings",
        ParentId = 68
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 73,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-car",
        Name = "Vehicles, chattels",
        ParentId = 68
      });

      // Income

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 74,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-currency-usd",
        Name = "Income"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 75,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-newspaper",
        Name = "Checks, coupons",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 76,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-account-child",
        Name = "Child Support",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 77,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-check-decagram",
        Name = "Dues & grants",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 78,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-gift",
        Name = "Gifts",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 79,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-ticket-percent",
        Name = "Interests, dividends",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 80,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-currency-usd",
        Name = "Lending, renting",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 81,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-dice-5",
        Name = "Lottery, gambling",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 82,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-undo",
        Name = "Refunds (tax, purchase)",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 83,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-home",
        Name = "Rental income",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 84,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-sale",
        Name = "Sale",
        ParentId = 74
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 85,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-currency-usd",
        Name = "Wage, invoices",
        ParentId = 74
      });

      // Others

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 86,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
        Color = "#ffffff",
        Icon = "mdi-account-question",
        Name = "Others"
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 87,
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
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
