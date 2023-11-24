using LinkShorteningSite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LinkShorteningSite.Data
{
    public class LinkShorteningSiteContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LinkShorteningSiteContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            Database.Migrate();

        }

        public DbSet<Url> Urls { get; set; }
    }
}