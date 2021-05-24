using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace fin_app_backend
{
  public partial class finappContext : DbContext
  {
    public finappContext()
    {
    }

    public finappContext(DbContextOptions<finappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appsetting> Appsettings { get; set; }
    public virtual DbSet<Appuser> Appusers { get; set; }
    public virtual DbSet<Financialchange> Financialchanges { get; set; }
    public virtual DbSet<Financialchangetag> Financialchangetags { get; set; }
    public virtual DbSet<Financialhistory> Financialhistories { get; set; }
    public virtual DbSet<Locale> Locales { get; set; }
    public virtual DbSet<Paymentsource> Paymentsources { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseMySql("", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.32-mysql"));
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasCharSet("latin1");

      modelBuilder.Entity<Appsetting>(entity =>
      {
        entity.ToTable("appsetting");

        entity.HasCharSet("utf8")
                  .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.AppUserId, "appUserId");

        entity.HasIndex(e => e.LocaleId, "appsetting_ibfk_2");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.AppUserId)
                  .HasColumnType("int(11)")
                  .HasColumnName("appUserId");

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

        entity.HasOne(d => d.AppUser)
                  .WithMany(p => p.Appsettings)
                  .HasForeignKey(d => d.AppUserId)
                  .HasConstraintName("appsetting_ibfk_1");

        entity.HasOne(d => d.Locale)
                  .WithMany(p => p.Appsettings)
                  .HasForeignKey(d => d.LocaleId)
                  .HasConstraintName("appsetting_ibfk_2");
      });

      modelBuilder.Entity<Appuser>(entity =>
      {
        entity.ToTable("appuser");

        entity.HasCharSet("utf8")
                  .UseCollation("utf8_general_ci");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.DisplayName)
                  .HasMaxLength(255)
                  .HasColumnName("displayName");

        entity.Property(e => e.Email)
                  .HasMaxLength(255)
                  .HasColumnName("email");

        entity.Property(e => e.EmailConfirmed)
                  .HasColumnType("tinyint(4)")
                  .HasColumnName("emailConfirmed");

        entity.Property(e => e.Password)
                  .HasMaxLength(255)
                  .HasColumnName("password");

        entity.Property(e => e.PhotoUrl)
                  .HasMaxLength(255)
                  .HasColumnName("photoURL");

        entity.Property(e => e.Uid)
                  .HasMaxLength(255)
                  .HasColumnName("uid");
      });

      modelBuilder.Entity<Financialchange>(entity =>
      {
        entity.ToTable("financialchange");

        entity.HasCharSet("utf8")
                  .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.AppUserId, "appUserId");

        entity.HasIndex(e => e.PaymentSourceId, "paymentSourceId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.Amount).HasColumnName("amount");

        entity.Property(e => e.AppUserId)
                  .HasColumnType("int(11)")
                  .HasColumnName("appUserId");

        entity.Property(e => e.CreatedAt)
                  .HasColumnType("datetime")
                  .HasColumnName("createdAt")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

        entity.Property(e => e.Description)
                  .HasMaxLength(255)
                  .HasColumnName("description");

        entity.Property(e => e.Expense).HasColumnName("expense");

        entity.Property(e => e.PaymentSourceId)
                  .HasColumnType("int(11)")
                  .HasColumnName("paymentSourceId");

        entity.Property(e => e.Transfer)
                  .HasColumnType("tinyint(4)")
                  .HasColumnName("transfer");

        entity.HasOne(d => d.AppUser)
                  .WithMany(p => p.Financialchanges)
                  .HasForeignKey(d => d.AppUserId)
                  .HasConstraintName("financialchange_ibfk_1");

        entity.HasOne(d => d.PaymentSource)
                  .WithMany(p => p.Financialchanges)
                  .HasForeignKey(d => d.PaymentSourceId)
                  .HasConstraintName("financialchange_ibfk_2");
      });

      modelBuilder.Entity<Financialchangetag>(entity =>
      {
        entity.ToTable("financialchangetag");

        entity.HasCharSet("utf8")
                  .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.FinancialChangeId, "financialChangeId");

        entity.HasIndex(e => e.TagId, "tagId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.FinancialChangeId)
                  .HasColumnType("int(11)")
                  .HasColumnName("financialChangeId");

        entity.Property(e => e.TagId)
                  .HasColumnType("int(11)")
                  .HasColumnName("tagId");

        entity.HasOne(d => d.FinancialChange)
                  .WithMany(p => p.Financialchangetags)
                  .HasForeignKey(d => d.FinancialChangeId)
                  .HasConstraintName("financialchangetag_ibfk_1");

        entity.HasOne(d => d.Tag)
                  .WithMany(p => p.Financialchangetags)
                  .HasForeignKey(d => d.TagId)
                  .HasConstraintName("financialchangetag_ibfk_2");
      });

      modelBuilder.Entity<Financialhistory>(entity =>
      {
        entity.ToTable("financialhistory");

        entity.HasCharSet("utf8")
                  .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.AppUserId, "appUserId");

        entity.HasIndex(e => e.PaymentSourceId, "paymentSourceId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.Amount).HasColumnName("amount");

        entity.Property(e => e.AppUserId)
                  .HasColumnType("int(11)")
                  .HasColumnName("appUserId");

        entity.Property(e => e.CreatedAt)
                  .HasColumnType("datetime")
                  .HasColumnName("createdAt")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

        entity.Property(e => e.PaymentSourceId)
                  .HasColumnType("int(11)")
                  .HasColumnName("paymentSourceId");

        entity.HasOne(d => d.AppUser)
                  .WithMany(p => p.Financialhistories)
                  .HasForeignKey(d => d.AppUserId)
                  .HasConstraintName("financialhistory_ibfk_2");

        entity.HasOne(d => d.PaymentSource)
                  .WithMany(p => p.Financialhistories)
                  .HasForeignKey(d => d.PaymentSourceId)
                  .HasConstraintName("financialhistory_ibfk_1");
      });

      modelBuilder.Entity<Locale>(entity =>
      {
        entity.ToTable("locale");

        entity.HasCharSet("utf8")
                  .UseCollation("utf8_general_ci");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.Text)
                  .HasMaxLength(50)
                  .HasColumnName("text");
      });

      modelBuilder.Entity<Paymentsource>(entity =>
      {
        entity.ToTable("paymentsource");

        entity.HasCharSet("utf8")
                  .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.AppUserId, "appUserId");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.AppUserId)
                  .HasColumnType("int(11)")
                  .HasColumnName("appUserId");

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

        entity.HasOne(d => d.AppUser)
                  .WithMany(p => p.Paymentsources)
                  .HasForeignKey(d => d.AppUserId)
                  .HasConstraintName("paymentsource_ibfk_1");
      });

      modelBuilder.Entity<Tag>(entity =>
      {
        entity.ToTable("tag");

        entity.HasCharSet("utf8")
                  .UseCollation("utf8_general_ci");

        entity.Property(e => e.Id)
                  .HasColumnType("int(11)")
                  .HasColumnName("id");

        entity.Property(e => e.Description)
                  .HasMaxLength(255)
                  .HasColumnName("description");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
