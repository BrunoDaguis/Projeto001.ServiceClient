using Microsoft.EntityFrameworkCore;
using Project001.ServiceClient.Domain.Entities;

namespace Project001.ServiceClient.Infra.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<ClientEntity> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>().Property(x => x.Id);
            modelBuilder.Entity<ClientEntity>().Property(x => x.Name).HasMaxLength(120).IsRequired();
            modelBuilder.Entity<ClientEntity>().Property(x => x.BirthDate).IsRequired();
            modelBuilder.Entity<ClientEntity>().Property(x => x.TypeDocument).IsRequired();
            modelBuilder.Entity<ClientEntity>().Property(x => x.NumberDocument).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<ClientEntity>().Property(x => x.Status).IsRequired();
        }
    }
}
