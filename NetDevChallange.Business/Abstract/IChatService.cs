using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.Abstract
{
    public interface IChatService
    {
        Task<List<Chat>> GetAllByChannelIdAsync(int channelId);
        Task<Chat> AddAsync(Chat chat);
    }
}
