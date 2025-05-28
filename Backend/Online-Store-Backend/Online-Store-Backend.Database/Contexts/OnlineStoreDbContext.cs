using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store_Backend.Database.Products.Models;
using Online_Store_Backend.Database.Categories.Models;
using Online_Store_Backend.Database.Orders.Models;
using Online_Store_Backend.Database.Permissions.Models;
using Online_Store_Backend.Database.Users.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Online_Store_Backend.Database.Employees.Models;

namespace Online_Store_Backend.Database.Contexts
{
    public partial class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductPropValue> ProductPropValues { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<EmployeePermission> EmployeePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<EmployeeToken> EmployeeTokens { get; set; }
    }
}
