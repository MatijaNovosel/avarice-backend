using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
  public partial class finappContext : IdentityDbContext<User>
  {
    public IConfiguration Configuration { get; }

    public finappContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public finappContext(DbContextOptions<finappContext> options, IConfiguration configuration) : base(options)
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
          .HasColumnName("id");

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
        Id = 5,
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
        Icon = "mdi-paw",
        Name = "Pets, animals",
        ParentId = 7
      });

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 19,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "#ffffff",
        Icon = "mdi-hammer-screwdriver",
        Name = "Stationery, tools",
        ParentId = 7
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
