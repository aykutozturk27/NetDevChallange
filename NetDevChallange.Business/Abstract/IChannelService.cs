using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.Abstract
{
    public interface IChannelService
    {
        Task<List<Channel>> GetAll();
    }
}
