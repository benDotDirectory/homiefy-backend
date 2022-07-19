using homiefy_backend.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace homiefy_backend.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<AuthorizationCredential> AuthenticationCredentials { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // ...
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AuthorizationCredential>().ToTable("AuthenticationCredentials");
            builder.Entity<AuthorizationCredential>().HasKey(p => p.Id);
            builder.Entity<AuthorizationCredential>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<AuthorizationCredential>().Property(p => p.ClientId).IsRequired();
            builder.Entity<AuthorizationCredential>().Property(p => p.ClientSecret).IsRequired();
 
        }
    }
}
