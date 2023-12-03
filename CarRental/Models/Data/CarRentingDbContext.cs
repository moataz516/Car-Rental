using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models.Data
{
    public class CarRentingDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Car_CarFeature> Car_CarFeatures { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserPayment> UserPayments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the primary keys for each entity
            modelBuilder.Entity<Car>().HasKey(c => c.CarId);
            modelBuilder.Entity<Car_CarFeature>().HasKey(ccf => new { ccf.CarId, ccf.CarFeatureId });
            modelBuilder.Entity<VehicleType>().HasKey(vt => vt.VehicleTypeId);
            modelBuilder.Entity<Brand>().HasKey(b => b.BrandId);
            modelBuilder.Entity<CarFeature>().HasKey(cf => cf.CarFeatureId);
            modelBuilder.Entity<Reservation>().HasKey(r => r.ReservationId);
            modelBuilder.Entity<Payment>().HasKey(p=> p.PaymentId);
            modelBuilder.Entity<UserDetails>().HasKey(p=> p.UserDetailsId);
            modelBuilder.Entity<ContactUs>().HasKey(p => p.ContactUsId);



            // Configure relationships between entities

            // user - user-details (one-to-one)
            modelBuilder.Entity<UserDetails>()
                .HasOne(p => p.User)
                .WithOne(r => r.UserDetails)
                .HasForeignKey<UserDetails>(p => p.UserId).OnDelete(DeleteBehavior.Cascade); ;


            // Car - Brand (Many-to-One)
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.SetNull); // Or other DeleteBehavior options based on your requirements

            // Car - VehicleType (Many-to-One)
            modelBuilder.Entity<Car>()
                .HasOne(c => c.VehicleType)
                .WithMany(vt => vt.Cars)
                .HasForeignKey(c => c.VehicleTypeId)
                .OnDelete(DeleteBehavior.SetNull); // Or other DeleteBehavior options based on your requirements

            // Car - ApplicationUser (Many-to-One)
            modelBuilder.Entity<Car>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull); // Or other DeleteBehavior options based on your requirements

            // Car - Car_CarFeature (One-to-Many)
            modelBuilder.Entity<Car>()
                .HasMany(c => c.CarFeatures)
                .WithOne(ccf => ccf.Car)
                .HasForeignKey(ccf => ccf.CarId)
                .OnDelete(DeleteBehavior.SetNull); // Or other DeleteBehavior options based on your requirements

            // CarFeature - Car_CarFeature (One-to-Many)
            modelBuilder.Entity<CarFeature>()
                .HasMany(cf => cf.Cars)
                .WithOne(ccf => ccf.CarFeature)
                .HasForeignKey(ccf => ccf.CarFeatureId)
                .OnDelete(DeleteBehavior.SetNull); // Or other DeleteBehavior options based on your requirements

            // Payment - Reservation (One-to-Many)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Reservation)
                .WithOne(r => r.Payment)
                .HasForeignKey<Payment>(p => p.ReservationId);

            // Payment - User (One-to-Many)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(r => r.Payments)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.SetNull);


            // ContactUs - User (many-to-one)
            modelBuilder.Entity<ContactUs>()
                .HasOne(u => u.User)
                .WithMany(c => c.ContactUs)
                .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade); 
            
            ;
        }

    }

}
