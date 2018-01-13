using ForumApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ForumApp.Infrastructure.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
    }

    public static class DatabaseHelper {
        public static void InjectDbContext(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ForumAppDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
