namespace Sunburst.Data
{
    using Duende.IdentityServer.EntityFramework.Options;
    using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models;
    using System.Reflection.Emit;

    public class SunburstDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public DbSet<Cart> Carts { get; set; }
        public DbSet<History> Hitories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ItemInCart> ItemsInCarts { get; set; }

        public SunburstDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(c => c.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Item>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<CartItem>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18, 2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}