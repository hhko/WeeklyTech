namespace FluentValidationExt.Controllers.Students.DataContracts;

public record RegisterRequest(
    AddressDto[]? Addresses);
