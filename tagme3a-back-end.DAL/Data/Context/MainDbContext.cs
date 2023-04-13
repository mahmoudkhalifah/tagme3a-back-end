using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using tagme3a_back_end.DAL.Data.Models;
using System.Reflection.Emit;

namespace tagme3a_back_end.DAL.Data.Context
{
    public class MainDbContext : IdentityDbContext<User>
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UsersClaims");

            builder.Entity<ProductCompatibility>()
            .HasKey(pc => new { pc.ProductId, pc.CompatibleProductId });

            builder.Entity<ProductCompatibility>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.CompatibleProducts)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductCompatibility>()
                .HasOne(pc => pc.CompatibleProduct)
                .WithMany()
                .HasForeignKey(pc => pc.CompatibleProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductOrder>()
                .HasKey(e=> new {e.OrderId, e.ProductId});


            builder.Entity<ProductPC>()
                .HasKey(e => new { e.PCId, e.ProductId });


            builder.Entity<Review>()
                .HasKey(e => new { e.UserId, e.ProductId });

            builder.Entity<UserProductInCart>()
                .HasKey(e => new { e.UserId, e.ProductId });
        }

        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<PC> PCs => Set<PC>();
        public DbSet<ProductPC> ProductPCs => Set<ProductPC>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCompatibility> ProductsCompatibility => Set<ProductCompatibility>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();
        public DbSet<ProductOrder> ProductOrders => Set<ProductOrder>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<UserProductInCart> UserProductInCarts => Set<UserProductInCart>();

    }
}
