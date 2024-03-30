using FluentValidation;
using ICI.ProvaCandidato.Web.Models;

namespace ICI.ProvaCandidato.Dados.Entity.Validator
{
    public class TagValidator : AbstractValidator<TagEntity>
    {
        public TagValidator()
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();
        }
    }
}