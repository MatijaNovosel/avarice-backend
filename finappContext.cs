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
    public virtual DbSet<History> Histories { get; set; }
    public virtual DbSet<Locale> Locales { get; set; }
    public virtual DbSet<Setting> Settings { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<Transactiontag> Transactiontags { get; set; }

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

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.Currency)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnName("currency")
                  .HasDefaultValueSql("'HRK'");

        entity.Property(e => e.Description)
                  .HasMaxLength(255)
                  .HasColumnName("description");

        entity.Property(e => e.Icon)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnName("icon")
                  .HasDefaultValueSql("'eye'");

        entity.Property(e => e.UserId)
                  .HasColumnName("userId");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Accounts)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("account_ibfk_1");
      });

      modelBuilder.Entity<History>(entity =>
      {
        entity.ToTable("history");

        entity.HasCharSet("latin1")
                  .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.AccountId, "accountId");

        entity.HasIndex(e => e.UserId, "userId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.AccountId)
                  .HasColumnType("int(11)")
                  .HasColumnName("accountId");

        entity.Property(e => e.Amount).HasColumnName("amount");

        entity.Property(e => e.CreatedAt)
                  .HasColumnType("datetime")
                  .HasColumnName("createdAt")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

        entity.Property(e => e.UserId)
                  .HasColumnName("userId");

        entity.HasOne(d => d.Account)
                  .WithMany(p => p.Histories)
                  .HasForeignKey(d => d.AccountId)
                  .HasConstraintName("history_ibfk_1");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Histories)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("history_ibfk_2");
      });

      modelBuilder.Entity<Locale>(entity =>
      {
        entity.ToTable("locale");

        entity.HasCharSet("latin1")
                  .UseCollation("latin1_swedish_ci");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.Text)
                  .HasMaxLength(50)
                  .HasColumnName("text");
      });

      modelBuilder.Entity<Setting>(entity =>
      {
        entity.ToTable("settings");

        entity.HasCharSet("latin1")
                  .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.LocaleId, "settings_ibfk_2");

        entity.HasIndex(e => e.UserId, "userId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.DarkMode).HasColumnName("darkMode");

        entity.Property(e => e.DateFormat)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnName("dateFormat")
                  .HasDefaultValueSql("'dd.MM.yyyy. HH:mm'");

        entity.Property(e => e.LocaleId)
                  .HasColumnType("int(11)")
                  .HasColumnName("localeId");

        entity.Property(e => e.PreferredCurrency)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnName("preferredCurrency")
                  .HasDefaultValueSql("'HRK'");

        entity.Property(e => e.UserId)
                  .HasColumnName("userId");

        entity.HasOne(d => d.Locale)
                  .WithMany(p => p.Settings)
                  .HasForeignKey(d => d.LocaleId)
                  .HasConstraintName("settings_ibfk_2");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Settings)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("settings_ibfk_1");
      });

      modelBuilder.Entity<Tag>(entity =>
      {
        entity.ToTable("tag");

        entity.HasCharSet("latin1")
                  .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.UserId, "userId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.Description)
                  .HasMaxLength(255)
                  .HasColumnName("description");

        entity.Property(e => e.UserId)
                  .HasColumnName("userId");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Tags)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("tag_ibfk_1");
      });

      modelBuilder.Entity<Transaction>(entity =>
      {
        entity.ToTable("transaction");

        entity.HasCharSet("latin1")
                  .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.AccountId, "accountId");

        entity.HasIndex(e => e.UserId, "userId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.AccountId)
                  .HasColumnType("int(11)")
                  .HasColumnName("accountId");

        entity.Property(e => e.Amount).HasColumnName("amount");

        entity.Property(e => e.CreatedAt)
                  .HasColumnType("datetime")
                  .HasColumnName("createdAt")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

        entity.Property(e => e.Description)
                  .HasMaxLength(255)
                  .HasColumnName("description");

        entity.Property(e => e.Expense).HasColumnName("expense");

        entity.Property(e => e.Transfer)
                  .HasColumnType("tinyint(4)")
                  .HasColumnName("transfer");

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
      });

      modelBuilder.Entity<Transactiontag>(entity =>
      {
        entity.ToTable("transactiontag");

        entity.HasCharSet("latin1")
                  .UseCollation("latin1_swedish_ci");

        entity.HasIndex(e => e.TagId, "tagId");

        entity.HasIndex(e => e.TransactionId, "transactionId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.TagId)
                  .HasColumnType("int(11)")
                  .HasColumnName("tagId");

        entity.Property(e => e.TransactionId)
                  .HasColumnType("int(11)")
                  .HasColumnName("transactionId");

        entity.HasOne(d => d.Tag)
                  .WithMany(p => p.Transactiontags)
                  .HasForeignKey(d => d.TagId)
                  .HasConstraintName("transactiontag_ibfk_2");

        entity.HasOne(d => d.Transaction)
                  .WithMany(p => p.Transactiontags)
                  .HasForeignKey(d => d.TransactionId)
                  .HasConstraintName("transactiontag_ibfk_1");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
