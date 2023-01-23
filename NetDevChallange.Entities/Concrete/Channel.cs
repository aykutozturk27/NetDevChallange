using NetDevChallange.Core.Entities;

namespace NetDevChallange.Entities.Concrete
{
    public class Channel : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<Chat>? Chats { get; set; }
    }
}
