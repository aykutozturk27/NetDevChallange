using Autofac;
using NetDevChallange.Business.Abstract;
using NetDevChallange.Business.Concrete.Managers;
using NetDevChallange.Core.DataAccess.Redis;
using NetDevChallange.DataAccess.Abstract;
using NetDevChallange.DataAccess.Concrete.EntityFramework;

namespace NetDevChallange.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<ChatManager>().As<IChatService>();
            builder.RegisterType<EfChatDal>().As<IChatDal>();

            builder.RegisterType<ChannelManager>().As<IChannelService>();
            builder.RegisterType<EfChannelDal>().As<IChannelDal>();

            builder.RegisterType<RedisBaseRepository>().As<IRedisBaseRepository>();
        }
    }
}
