using FluentValidation;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
        }
    }
}
