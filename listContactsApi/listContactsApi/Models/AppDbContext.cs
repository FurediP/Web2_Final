using listContactsApi.Entities;
using listContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace listContactsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TypeContact> typecontacts { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeContact>().ToTable("typecontacts");
            modelBuilder.Entity<Contact>().ToTable("contacts");
            modelBuilder.Entity<User>().ToTable("users");

        }
    }
}
