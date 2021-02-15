using Microsoft.EntityFrameworkCore;

namespace appWizard.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<RegisterModelUser> RegisterModelUsers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
