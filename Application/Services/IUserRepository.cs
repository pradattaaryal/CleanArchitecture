using practices.Model;

namespace practices.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task<bool> UserExistsAsync(string email);
    }

}
