using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProdsAndCatsSecondAttempt.Data
{
    public class ProdsAndCatsSecondAttemptContext : DbContext
    {
        public ProdsAndCatsSecondAttemptContext (DbContextOptions<ProdsAndCatsSecondAttemptContext> options)
            : base(options)
        {
        }

        public DbSet<ProductsAndCategories.Models.Categorie> Categorie { get; set; }

        public DbSet<ProductsAndCategories.Models.Product> Product { get; set; }

        public DbSet<ProductJoinCategory> ProductJoinCategorys { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductJoinCategory>()
                .HasKey(PC => new {PC.ProductID, PC.CategoryID});
            modelBuilder.Entity<ProductJoinCategory>()
                .HasOne(PC => PC.Product)
                .WithMany(p => p.ProductCategorys)
                .HasForeignKey(PC => PC.ProductID);
            modelBuilder.Entity<ProductJoinCategory>()
                .HasOne(pc => pc.Categorie)
                .WithMany(c => c.ProductCategorys)
                .HasForeignKey(bc => bc.CategoryID);
        }

    }
}
