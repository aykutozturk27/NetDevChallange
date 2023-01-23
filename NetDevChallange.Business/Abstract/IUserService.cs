using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.Abstract
{
    public interface IUserService
    {
        Task<User> Add(User user);
        Task<User> GetById(int id);
    }
}
