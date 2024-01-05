namespace FluentValidationExt.Controllers.Students.DataContracts;

public record AddressDto(
    string? Street,
    string? City,
    string? State,
    string? ZipCode);
