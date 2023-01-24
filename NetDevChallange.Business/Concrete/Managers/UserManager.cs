using NetDevChallange.Business.Abstract;
using NetDevChallange.DataAccess.Abstract;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<User> AddAsync(User user)
        {
            var userCheck = await _userDal.GetAsync(x => x.UserName == user.UserName);
            if (userCheck == null)
            {
                return await _userDal.AddAsync(user);
            }
            return userCheck;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userDal.GetAsync(x => x.Id == id);
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _userDal.GetAsync(x => x.UserName == name);
        }
    }
}
