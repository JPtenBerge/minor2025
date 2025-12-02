using Demo.Shared.Entities;
using FluentValidation;

namespace BlazorApp1;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Naam graag");
        RuleFor(x => x.ExpectedScore).InclusiveBetween(1m, 10m).WithMessage("Tussen 1 en 10 graag");

        When(x => x.ExpectedScore > 5,
            () => { RuleFor(x => x.Name).MinimumLength(10).WithMessage("Hoge verwachting is lange naam!"); });

        // RuleForEach(x => x.Items, () =>
        // {
        //     
        // });
    }
}