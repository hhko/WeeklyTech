using FluentValidation.Results;
using FluentValidationExt.Controllers.Students.DataContracts;
using FluentValidationExt.Controllers.Students.Validations;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExt.Controllers.Students;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        var validator = new RegisterRequestValidator();
        ValidationResult result = validator.Validate(request);
        if (result.IsValid is false)
        {
            return BadRequest(result.Errors[0].ErrorMessage);
        }

        return Ok();
    }
}
