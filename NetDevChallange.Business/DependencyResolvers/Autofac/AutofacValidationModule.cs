using Autofac;
using FluentValidation;
using NetDevChallange.Business.ValidationRules.FluentValidation;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.DependencyResolvers.Autofac
{
    public class AutofacValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserValidator>().As<IValidator<User>>().SingleInstance();
        }
    }
}
