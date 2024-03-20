using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;
using System;

namespace WebApplication1
{
    public class TripsDatabaseContext : DbContext
    {
        private string ConnectionString { get => @"Data Source=DESKTOP-M5KPVQV\SQLEXPRESS;Initial Catalog=TripDatabase;Integrated Security=True;TrustServerCertificate=True"; }
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter() : base(
                v => new DateTime(v.Year, v.Month, v.Day),
                v => DateOnly.FromDateTime(v))
            {
            }
        }
        public TripsDatabaseContext()
        {
        }

        public TripsDatabaseContext(DbContextOptions<TripsDatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<TripGuide> TripGuides { get; set; }
        public virtual DbSet<TripParticipant> TripParticipants { get; set; }
        public virtual DbSet<TripReview> TripReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.TripId).HasName("PK_Trip");
                entity.Property(e => e.TripId).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Place).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasConversion(new DateOnlyConverter());
                entity.Property(e => e.Duration).IsRequired();

        });
            modelBuilder.Entity<TripGuide>(entity =>
            {
                entity.HasKey(e => e.GuideId).HasName("PK_TripGuide");
                entity.Property(e => e.GuideId).ValueGeneratedOnAdd();
                entity.Property(e => e.TripId).IsRequired();
                entity.Property(e => e.GuideName).IsRequired();
                entity.Property(e => e.GuidePhoneNumber).IsRequired();
                entity.Property(e => e.GuideEmail).IsRequired();
            });
            modelBuilder.Entity<TripParticipant>(entity =>
            {
                entity.HasKey(e => e.ParticipantId).HasName("PK_TripParticipant");
                entity.Property(e => e.ParticipantId).ValueGeneratedOnAdd();
                entity.Property(e => e.TripId).IsRequired();
                entity.Property(e => e.ParticipantName).IsRequired();
                entity.Property(e => e.ParticipantEmail).IsRequired();
                entity.Property(e => e.ParticipantPhoneNumber).IsRequired();
            });
            modelBuilder.Entity<TripReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId).HasName("PK_TripReview");
                entity.Property(e => e.ReviewId).ValueGeneratedOnAdd();
                entity.Property(e => e.TripParticipantId).IsRequired();
                entity.Property(e => e.Rating).IsRequired();
            });
        }
    }
}
