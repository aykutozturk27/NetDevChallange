using NetDevChallange.Core.DataAccess;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.DataAccess.Abstract
{
    public interface IChatDal : IEntityRepository<Chat>
    {
    }
}
