using Microsoft.EntityFrameworkCore;
using ReservationService.Models;

namespace ReservationService.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<Waitlist> Waitlist { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModel>().HasData(
            new CustomerModel { CustomerId = "C101", Name = "Jone Doe", Email = "john.doe@example.com" },
            new CustomerModel { CustomerId = "C102", Name = "Jane Smith", Email = "jane.smith@example.com" },
            new CustomerModel { CustomerId = "C103", Name = "Sam Wilson", Email = "sam.wilson@example.com" },
            new CustomerModel { CustomerId = "C104", Name = "Emily Davis", Email = "emily.davis@example.com" });
        }
    }

}
