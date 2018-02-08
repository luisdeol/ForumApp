using System.Threading.Tasks;

namespace ForumApp.Core.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task AddApplicationUser(ApplicationUser user);
    }
}