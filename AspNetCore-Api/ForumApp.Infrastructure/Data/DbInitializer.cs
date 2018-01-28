namespace ForumApp.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ForumAppDbContext context) {
            context.Database.EnsureCreated();
        }
    }
}