namespace Sunburst.Data
{
    using Duende.IdentityServer.EntityFramework.Options;
    using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Sunburst.Models;
    using Sunburst.Models.Shop;

    public class SunburstDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public DbSet<Cart> Carts { get; set; }
        public DbSet<History> Hitories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Set> Sets { get; set; }

        public SunburstDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
            
        }
    }
}