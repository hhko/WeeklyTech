using FluentValidation;
using FluentValidationExt.Controllers.Students.DataContracts;

namespace FluentValidationExt.Controllers.Students.Validations;

public class AddressValidator : AbstractValidator<AddressDto>
{
    public AddressValidator()
    {
        RuleFor(x => x.Street).NotEmpty().Length(0, 100);
        RuleFor(x => x.City).NotEmpty().Length(0, 100);
        RuleFor(x => x.State).NotEmpty().Length(0, 100);
        RuleFor(x => x.ZipCode).NotEmpty().Length(0, 100);
    }
}
