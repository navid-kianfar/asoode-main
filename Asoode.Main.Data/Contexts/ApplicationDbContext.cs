using Asoode.Main.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Asoode.Main.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ContextOverrides.OnModelCreating(modelBuilder);
        }
    }
}