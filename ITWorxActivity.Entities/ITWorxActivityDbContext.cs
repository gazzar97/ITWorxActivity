using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITWorxActivity.Entities
{
    public class ITWorxActivityDbContext : DbContext
    {
        public ITWorxActivityDbContext(DbContextOptions options):base(options)
        {


        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryID = 1, Name = "Fruit" },
                new Category() { CategoryID = 2, Name = "Vegetables" },
                new Category() { CategoryID = 3, Name = "Mobiles" },
                new Category() { CategoryID = 4, Name = "Laptops" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductID = 1, Name = "Apple", Price = 5, Qunatity = 2, CategoryID = 1 }
                );
        }
    }
}
