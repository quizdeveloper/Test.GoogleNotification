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

        public virtual DbSet<NotifyHistory> NotifyHistory { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9HHLK4D;Database=GoogleNotification;user id=sa;password=sa@12345;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotifyHistory>(entity =>
            {
                entity.Property(e => e.PushDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasComment("true : push ok, false : can't push");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IpAddress).HasMaxLength(100);

                entity.Property(e => e.SubscribeToken)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
