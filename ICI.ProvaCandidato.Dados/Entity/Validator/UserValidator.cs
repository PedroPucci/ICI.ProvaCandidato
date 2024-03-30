using FluentValidation;
using ICI.ProvaCandidato.Web.Models;

namespace ICI.ProvaCandidato.Dados.Entity.Validator
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Mail)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}