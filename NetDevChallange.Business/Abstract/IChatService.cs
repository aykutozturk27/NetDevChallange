using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.Abstract
{
    public interface IChatService
    {
        Task<List<Chat>> GetAllByChannelId(int channelId);
        Task<Chat> Add(Chat chat);
    }
}
