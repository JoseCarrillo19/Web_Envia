using Microsoft.EntityFrameworkCore;
using Web_Envia.Models;

namespace Web_Envia.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Guides> Guias { get; set; }
    }
}
