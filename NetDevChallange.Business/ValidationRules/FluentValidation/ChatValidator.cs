using FluentValidation;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.Business.ValidationRules.FluentValidation
{
    public class ChatValidator : AbstractValidator<Chat>
    {
        public ChatValidator()
        {
            RuleFor(u => u.Message).NotEmpty().WithMessage("Mesaj boş geçilemez");
        }
    }
}
