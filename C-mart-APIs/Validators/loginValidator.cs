using C_mart_APIs.Model;
using FluentValidation;

namespace C_mart_APIs.Validators
{
    public class loginValidator :AbstractValidator<LoginRequest>
    {
        public loginValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
