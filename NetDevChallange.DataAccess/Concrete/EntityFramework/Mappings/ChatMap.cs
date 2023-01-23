using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ChatMap : BaseMap<Chat>
    {
        public override void ConfigureMap(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable(@"Chat", @"dbo");

            builder.Property(a => a.Message).HasColumnName("Message");

            builder.HasOne(a => a.User).WithMany(a => a.Chats).HasForeignKey(a => a.UserId);
            builder.HasOne(a => a.Channel).WithMany(a => a.Chats).HasForeignKey(a => a.ChannelId);
        }
    }
}
