using FluentValidation;
using ICI.ProvaCandidato.Web.Models;

namespace ICI.ProvaCandidato.Dados.Entity.Validator
{
    public class NoticeValidator : AbstractValidator<NoticeEntity>
    {
        public NoticeValidator()
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Text)
                .NotEmpty();
        }
    }
}