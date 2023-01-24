using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.MvcWebUI.Models
{
    public class GeneralModel
    {
        public Chat? Chat { get; set; }
        public List<Chat>? Chats { get; set; }
        public List<Channel>? Channels { get; set; }
    }
}
