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
        public DbSet<Comment> Comments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c=> c.PostId);

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Content)
                .IsRequired();
        }
    }
}
