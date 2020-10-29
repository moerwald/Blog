using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) :base (options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
