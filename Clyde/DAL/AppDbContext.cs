using Clyde.Models;
using Microsoft.EntityFrameworkCore;

namespace Clyde.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<About> About{ get; set; }
    }
}
