using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using e_commerce.Authorization.Roles;
using e_commerce.Authorization.Users;
using e_commerce.MultiTenancy;
using e_commerce.Domain;

namespace e_commerce.EntityFrameworkCore
{
    public class e_commerceDbContext : AbpZeroDbContext<Tenant, Role, User, e_commerceDbContext>
    {
        /* Define a DbSet for each entity of the application */
       public DbSet<Customer> Customers { get; set; }
       public DbSet<Questions> Questions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public e_commerceDbContext(DbContextOptions<e_commerceDbContext> options)
            : base(options)
        {
        }
    }
}
