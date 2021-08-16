using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

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
                  .HasColumnType("int(11)")
                  .HasColumnName("accountId");

        entity.Property(e => e.CategoryId)
                  .HasColumnType("int(11)")
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
                  .HasConstraintName("transaction_ibfk_2");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Transactions)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("transaction_ibfk_1");

        entity.HasOne(d => d.Category)
                  .WithMany(p => p.Transactions)
                  .HasForeignKey(d => d.CategoryId)
                  .HasConstraintName("transaction_ibfk_3");
      });

      modelBuilder.Entity<Category>(entity =>
      {
        entity.ToTable("category");

        entity.HasCharSet("latin1")
                  .UseCollation("latin1_swedish_ci");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.UserId)
                  .HasColumnName("userId");

        entity.Property(e => e.Name)
                  .HasMaxLength(32)
                  .HasColumnName("name");

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

      modelBuilder.Entity<Category>().HasData(new Category()
      {
        Id = 1,
        UserId = "ee103364-7617-4474-889e-320838e5f3a5",
        Color = "red",
        Icon = "mdi-account",
        Name = "Testing category"
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
