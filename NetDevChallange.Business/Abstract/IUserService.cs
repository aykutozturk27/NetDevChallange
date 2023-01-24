using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.Abstract
{
    public interface IUserService
    {
        Task<User> AddAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByNameAsync(string name);
        Task<List<User>> GetAllAsync();
    }
}
