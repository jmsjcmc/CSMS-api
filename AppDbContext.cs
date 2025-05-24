using Csms_api.Helpers;
using Csms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Csms_api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(d =>
            {
                d.HasOne(u => u.BusinessUnit)
                .WithMany(u => u.User)
                .HasForeignKey(u => u.BusinessUnit_id)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>(d =>
            {
                d.HasOne(p => p.Company)
                .WithMany(p => p.Product)
                .HasForeignKey(p => p.Company_id)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BusinessUnit>().HasData(
                new BusinessUnit
                {
                    Id = 1,
                    Business_unit = "ABFI Central Office",
                    BusinessUnit_location = "Sitio Sto.Nino, Brgy.Binugao, Toril, Davao City",
                    Removed = false,
                },
                new BusinessUnit
                {
                    Id = 2,
                    Business_unit = "SubZero Ice and Cold Storage",
                    BusinessUnit_location = "Binugao, Toril, Davao City",
                    Removed = false
                });
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Role_name = "Administrator",
                    Removed = false
                },
                new Role
                {
                    Id = 2,
                    Role_name = "User",
                    Removed = false
                },
                new Role
                {
                    Id = 3,
                    Role_name = "Approver",
                    Removed = false
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    First_name = "James Jecemeco",
                    Last_name = "Tabilog",
                    Username = "211072",
                    Password = BCrypt.Net.BCrypt.HashPassword("@temp123"),
                    Position = "Software Developer",
                    Department = "Cisdevo",
                    Role = "Administrator, User, Approver",
                    Removed = false,
                    E_signature = null,
                    Created_on = TimeHelper.GetPhilippineTime(),
                    Updated_on = null,
                    BusinessUnit_id = 1
                },
                new User
                {
                    Id = 2,
                    First_name = "Shiela",
                    Last_name = "Hernando",
                    Username = "211072",
                    Password = BCrypt.Net.BCrypt.HashPassword("@temp123"),
                    Position = "Senior Operations Manager",
                    Department = "Executive",
                    Role = "Approver",
                    Removed = false,
                    E_signature = null,
                    Created_on = TimeHelper.GetPhilippineTime(),
                    Updated_on = null,
                    BusinessUnit_id = 2
                });
        }
    }
}
