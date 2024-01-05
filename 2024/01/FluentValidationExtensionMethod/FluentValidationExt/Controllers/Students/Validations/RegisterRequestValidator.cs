using FluentValidation;
using FluentValidationExt.Controllers.Students.DataContracts;

namespace FluentValidationExt.Controllers.Students.Validations;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Addresses)
            .NotNull()
            .SetValidator(new AddressesValidator());
    }
}
