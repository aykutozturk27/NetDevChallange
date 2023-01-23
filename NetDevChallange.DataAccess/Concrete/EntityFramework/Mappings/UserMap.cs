using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : BaseMap<User>
    {
        public override void ConfigureMap(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(@"User", @"dbo");

            builder.Property(a => a.UserName).HasColumnName("UserName");
        }
    }
}
