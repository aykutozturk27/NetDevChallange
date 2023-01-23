using Microsoft.EntityFrameworkCore;
using NetDevChallange.Core.Utilities.Configuration;
using NetDevChallange.DataAccess.Concrete.EntityFramework.Mappings;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.DataAccess.Concrete.EntityFramework.Contexts
{
    public class NetDevChallangeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Channel> Channels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CoreConfig.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ChatMap());
            modelBuilder.ApplyConfiguration(new ChannelMap());
        }
    }
}
