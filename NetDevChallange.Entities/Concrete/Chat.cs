using NetDevChallange.Core.Entities;

namespace NetDevChallange.Entities.Concrete
{
    public class Chat : BaseEntity
    {
        public string? Message { get; set; }

        public int UserId { get; set; } 
        public User? User { get; set; }
        public int ChannelId { get; set; }
        public Channel? Channel { get; set; }
    }
}
