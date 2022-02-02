using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetUserAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}
