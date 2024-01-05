using FluentValidation;
using FluentValidationExt.Controllers.Students.DataContracts;

namespace FluentValidationExt.Controllers.Students.Validations;

public class AddressesValidator : AbstractValidator<AddressDto[]>
{
    public AddressesValidator()
    {
        RuleFor(x => x)
            // 배열 건수
            //.Must(x => x?.Length >= 1 && x.Length <= 3).WithMessage("The number of addresses must be between 1 and 3")
            .ListMustContainNumberOfItems(1, 3)

            // 배열 원소
            .ForEach(x => x.NotNull().SetValidator(new AddressValidator()));
    }
}
