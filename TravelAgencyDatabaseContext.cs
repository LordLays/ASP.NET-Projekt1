using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1
{
    public class TravelAgencyDatabaseContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public TravelAgencyDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Pobierz connectionString z pliku appsettings.json
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Skonfiguruj kontekst bazy danych
            optionsBuilder.UseSqlServer(connectionString);
        }

        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter() : base(
                v => new DateTime(v.Year, v.Month, v.Day),
                v => DateOnly.FromDateTime(v))
            {
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ofert> Oferts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasKey(h => h.ID);
            modelBuilder.Entity<Hotel>()
                .Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Hotel>()
                .Property(o => o.City)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Hotel>()
                .Property(o => o.Country)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Hotel>()
                .Property(o => o.Address)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Hotel>()
                .Property(o => o.StarRating)
                .IsRequired();
            modelBuilder.Entity<Hotel>()
                .Property(o => o.AverageCustomersRating)
                .HasColumnType("decimal(4, 2)");
            modelBuilder.Entity<Hotel>()
                .Property(o => o.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<Hotel>()
                .Property(o => o.ImageUrl)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                 );


            modelBuilder.Entity<HotelRoom>().HasKey(hr => hr.ID);
            modelBuilder.Entity<HotelRoom>()
                .Property(o => o.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<HotelRoom>()
                .Property(o => o.Type)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<TypeRoom>());
            modelBuilder.Entity<HotelRoom>()
                .Property(o => o.Capacity)
                .IsRequired();
            modelBuilder.Entity<HotelRoom>()
                .Property(o => o.Available)
                .IsRequired();
            modelBuilder.Entity<HotelRoom>()
                .Property(o => o.Description)
                .HasMaxLength(250);



            modelBuilder.Entity<Ofert>().HasKey(o => o.ID);
            modelBuilder.Entity<Ofert>()
                .Property(o => o.Country)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Ofert>()
                .Property(o => o.City)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Ofert>()
                .Property(o => o.TakeOffPlace)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Ofert>()
                .Property(o => o.AvailableSeats)
                .IsRequired();
            modelBuilder.Entity<Ofert>()
                .Property(o => o.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<Ofert>()
                .Property(o => o.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Ofert>()
                .Property(o => o.StartDate)
                .IsRequired()
                .HasConversion(new DateOnlyConverter());
            modelBuilder.Entity<Ofert>()
                .Property(o => o.EndDate)
                .IsRequired()
                .HasConversion(new DateOnlyConverter());


            modelBuilder.Entity<Customer>().HasKey(c => c.ID);
            modelBuilder.Entity<Customer>()
                .Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Customer>()
                .Property(o => o.Surname)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Customer>()
                .Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.Entity<Customer>()
                .Property(o => o.Phone)
                .IsRequired()
                .HasMaxLength(20);


            modelBuilder.Entity<Reservation>().HasKey(r => r.ID);
            modelBuilder.Entity<Reservation>()
                .Property(o => o.Travelers)
                .IsRequired();
            modelBuilder.Entity<Reservation>()
                .Property(o => o.Meal)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<Meal>()); ;
            modelBuilder.Entity<Reservation>()
                .Property(o => o.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");


            modelBuilder.Entity<Review>().HasKey(r => r.ID);
            modelBuilder.Entity<Review>()
                .Property(o => o.Rating)
                .IsRequired();
            modelBuilder.Entity<Review>()
                .Property(o => o.Reviews)
                .HasMaxLength(500);
            modelBuilder.Entity<Review>()
                .Property(o => o.Rating)
                .IsRequired();
            modelBuilder.Entity<Review>()
                .Property(o => o.Reviews)
                .HasMaxLength(500);


            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Hotel)
                .WithMany()
                .HasForeignKey(r => r.HotelID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.BookedRooms)
                .WithMany(hr => hr.Reservations);

            modelBuilder.Entity<HotelRoom>()
                .HasOne(hr => hr.Hotel)
                .WithMany(h => h.RoomList)
                .HasForeignKey(hr => hr.HotelID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
