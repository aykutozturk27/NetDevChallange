using NetDevChallange.Business.Abstract;
using NetDevChallange.DataAccess.Abstract;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.Concrete.Managers
{
    public class ChannelManager : IChannelService
    {
        private readonly IChannelDal _channelDal;

        public ChannelManager(IChannelDal channelDal)
        {
            _channelDal = channelDal;
        }

        public async Task<List<Channel>> GetAll()
        {
            return await _channelDal.GetListAsync();
        }
    }
}
