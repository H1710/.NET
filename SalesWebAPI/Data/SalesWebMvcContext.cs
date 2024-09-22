using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Models;

namespace SalesWebAPI.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departament> Departament { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!; // Ensure it's not null
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!; // Ensure it's not null
        public DbSet<Notes> Notes { get; set; } = default!; // Ensure it's not null

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .HasOne(s => s.Departament)
                .WithMany(d => d.Sellers)
                .HasForeignKey(s => s.DepartamentId)
                .OnDelete(DeleteBehavior.SetNull); // Set foreign key to null on delete

            // Add additional configurations here if needed
        }
    }
}
