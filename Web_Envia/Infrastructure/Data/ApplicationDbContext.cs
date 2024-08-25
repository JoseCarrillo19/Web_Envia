using Microsoft.EntityFrameworkCore;
using Web_Envia.Domain.Models;

namespace Web_Envia.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Guides> Guias { get; set; }
        public DbSet<Remitente> Remitentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guides>()
                .HasOne(g => g.Remitente)
                .WithMany() 
                .HasForeignKey(g => g.RemitenteId)
                .OnDelete(DeleteBehavior.Restrict); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
