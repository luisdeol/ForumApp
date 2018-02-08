using System.Threading.Tasks;
using ForumApp.Core;
using ForumApp.Core.Interfaces;

namespace ForumApp.Infrastructure.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ForumAppDbContext _context;

        public ApplicationUserRepository(ForumAppDbContext context)
        {
            _context = context;
        }

        public async Task AddApplicationUser(ApplicationUser user)
        {
            await _context.ApplicationUsers.AddAsync(user);
        }
    }
}
