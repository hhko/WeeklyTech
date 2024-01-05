using FluentValidationExt.Controllers.Students.DataContracts;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace FluentValidationExt.Tests.Integration;

[UsesVerify]
public partial class StudentControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public StudentControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Register_Succeed_WhenValidAddresses()
    {
        // Arrange
        using var httpClient = _factory.CreateDefaultClient();

        // Act: POST http://{{host}}/api/students
        using var response = await httpClient.PostAsJsonAsync($"api/students", new RegisterRequest(
            Addresses: [new AddressDto(
                Street: "3456 3rd St",
                City: "Carlington",
                State: "VA",
                ZipCode: "22203"
            )])
        );

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Register_Fail_WhenInvalidAddresses()
    {
        // Arrange
        using var httpClient = _factory.CreateDefaultClient();

        // Act: POST http://{{host}}/api/students
        using var response = await httpClient.PostAsJsonAsync($"api/students", new RegisterRequest(
            Addresses: [])
        );

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        await Verify(response.Content.ReadAsStringAsync());
    }
}