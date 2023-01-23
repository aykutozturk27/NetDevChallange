using NetDevChallange.Business.Abstract;
using NetDevChallange.Core.DataAccess.Redis;
using NetDevChallange.DataAccess.Abstract;
using NetDevChallange.Entities.Concrete;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetDevChallange.Business.Concrete.Managers
{
    public class ChatManager : IChatService
    {
        private readonly IChatDal _chatDal;
        private readonly IRedisBaseRepository _redisBaseRepository;

        public ChatManager(IChatDal chatDal, IRedisBaseRepository redisBaseRepository)
        {
            _chatDal = chatDal;
            _redisBaseRepository = redisBaseRepository;
        }

        public async Task<Chat> Add(Chat chat)
        {
            _redisBaseRepository.Set("chat", chat, duration: 5);
            var addedChat = _redisBaseRepository.Get<Chat>("chat");
            await _chatDal.AddAsync(chat);
            return addedChat;
        }

        public async Task<List<Chat>> GetAllByChannelId(int channelId)
        {
            var chatList = await _chatDal.GetListAsync(x => x.ChannelId == channelId, c => c.Channel);

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            string serialize = System.Text.Json.JsonSerializer.Serialize(chatList, options);
            _redisBaseRepository.Set("chat", serialize, duration: 5);
            return chatList;
        }
    }
}
