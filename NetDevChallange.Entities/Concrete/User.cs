using NetDevChallange.Core.Entities;

namespace NetDevChallange.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }//Nickname

        public ICollection<Chat>? Chats { get; set; }
    }
}
