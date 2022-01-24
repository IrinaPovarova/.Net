using Microsoft.EntityFrameworkCore;
using OrderManager.DAL.Entities;

namespace OrderManager.DAL.Context
{
    public class OrderManagerContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { modelBuilder.Entity<OrderDetail>().HasKey(c => new { c.OrderID, c.ProductID }); }
        public OrderManagerContext(DbContextOptions options) : base(options)
        {
        }
    }
}



   
