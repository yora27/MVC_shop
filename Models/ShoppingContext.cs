using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TaskAuthenticationAuthorization.Models
{
    public class ShoppingContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SuperMarket> SuperMarkets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BuyerType> BuyerTypes { get; set; }

        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "buyer";

            BuyerType[] buyerTypes =
            {
                new BuyerType { Id = 1, Name = "none"},
                new BuyerType { Id = 2,  Name = "regular"},
                new BuyerType { Id = 3,  Name = "golden"},
                new BuyerType { Id = 4,  Name = "wholesale"}
            };

            string adminEmail = "admin@gmail.com";
            string adminPassword = "11111";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User 
            { 
                Id = 1, 
                Email = adminEmail,
                Password = adminPassword,
                RoleId = adminRole.Id 
            };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            modelBuilder.Entity<BuyerType>().HasData(buyerTypes);

            base.OnModelCreating(modelBuilder);
        }
    }
}
