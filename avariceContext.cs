using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using avarice_backend.Utils;

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

        entity.Property(e => e.InitialBalance).HasColumnName("initialBalance");

        entity.Property(e => e.Id)
          .HasColumnType("bigint")
          .HasColumnName("id")
          .ValueGeneratedOnAdd();

        entity.Property(e => e.Currency)
          .IsRequired()
          .HasMaxLength(6)
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

        entity.Property(e => e.Longitude).HasColumnName("longitude");

        entity.Property(e => e.Latitude).HasColumnName("latitude");

        entity.Property(e => e.Description)
          .HasMaxLength(255)
          .HasColumnName("description");

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

        entity.HasOne(d => d.Category)
          .WithMany(p => p.Transactions)
          .HasForeignKey(d => d.CategoryId)
          .HasConstraintName("transaction_ibfk_3");
      });

      modelBuilder.Entity<Template>(entity =>
      {
        entity.ToTable("template");

        entity.HasCharSet("latin1")
          .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.AccountId, "accountId");

        entity.HasIndex(e => e.UserId, "userId");

        entity.HasIndex(e => e.CategoryId, "categoryId");

        entity.HasIndex(e => e.Longitude, "longitude");

        entity.HasIndex(e => e.Latitude, "latitude");

        entity.Property(e => e.CreatedAt)
          .HasColumnType("datetime")
          .HasColumnName("createdAt");

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
        InitialBalance = 14000,
        Currency = "HRK",
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 2,
        Name = "Euros",
        InitialBalance = 200,
        Currency = "EUR",
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 3,
        Name = "Checking",
        InitialBalance = 0,
        Currency = "HRK",
        UserId = "b2beece6-28da-4c7f-b304-3a526d166f00"
      });

      modelBuilder.Entity<Account>().HasData(new Account()
      {
        Id = 4,
        Name = "Pocket",
        InitialBalance = 800,
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

      int ctr = 2;

      foreach (KeyValuePair<Category, List<Category>> entry in PresetCategories.CategoriesDictionary)
      {
        modelBuilder.Entity<Category>().HasData(new Category()
        {
          Id = ctr++,
          UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
          Color = "#ffffff",
          Icon = entry.Key.Icon,
          Name = entry.Key.Name
        });

        foreach (var c in entry.Value)
        {
          modelBuilder.Entity<Category>().HasData(new Category()
          {
            Id = ctr++,
            UserId = "b2beece6-28da-4c7f-b304-3a526d166f00",
            Color = "#ffffff",
            Icon = c.Icon,
            Name = c.Name,
            ParentId = c.ParentId
          });
        }
      }

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
