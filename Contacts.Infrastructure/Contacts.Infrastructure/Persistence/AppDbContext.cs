using Contacts.Domain.Models;
using Contacts.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }
    }
}
