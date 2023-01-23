using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ChannelMap : BaseMap<Channel>
    {
        public override void ConfigureMap(EntityTypeBuilder<Channel> builder)
        {
            builder.ToTable(@"Channel", @"dbo");

            builder.Property(a => a.Name).HasColumnName("Name");
        }
    }
}
