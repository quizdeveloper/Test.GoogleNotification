using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.GoogleNotification.Dal.Entities
{
    public partial class GoogleNotificationContext : DbContext
    {
        public GoogleNotificationContext()
        {
        }

        public GoogleNotificationContext(DbContextOptions<GoogleNotificationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NotifyHistory> Notifyhistory { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=35.240.179.150;uid=dungdt;pwd=1234@1234aS;database=googlenotification");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotifyHistory>(entity =>
            {
                entity.ToTable("notifyhistory");

                entity.HasIndex(e => e.NotifyHistoryId)
                    .HasName("NotifyHistoryId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Link).HasMaxLength(150);

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.Status).HasColumnType("bit(1)");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IpAddress).HasMaxLength(100);

                entity.Property(e => e.SubscribeToken).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
