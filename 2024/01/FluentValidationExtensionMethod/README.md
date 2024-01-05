# 2024년 Weekly #01 | FluentValidation 확장 메서드

## 개요
- 유효성 검사를 명시적으로 개선한다.
  - 개선 전
    ```cs
    .Must(x => x?.Length >= 1 && x.Length <= 3).WithMessage("The number of addresses must be between 1 and 3")
    ```
  - 개선 후
    ```cs
    .ListMustContainNumberOfItems(1, 3)
    ```

## 배움
- FluentValidation 확장 메서드 구현 방법을 이해한다.

## 실행
- WebApi
- WebApi 통합 테스트

## 유효성 확장 메서드 사용
```cs
public class AddressesValidator : AbstractValidator<AddressDto[]>
{
    public AddressesValidator()
    {
        RuleFor(x => x)
            // 배열 건수
            //  - 개선 전
            //     .Must(x => x?.Length >= 1 && x.Length <= 3).WithMessage("The number of addresses must be between 1 and 3")
            //  - 개선 후
            .ListMustContainNumberOfItems(1, 3)

            // 배열 원소
            .ForEach(x => x.NotNull().SetValidator(new AddressValidator()));
    }
}
```

## 유효성 확장 메서드 구현
- RuleFor 메서드 리턴 값은 `IRuleBuilderInitial`입니다.
  ```
  IRuleBuilder
  ↑ 인터페이스 상속
  IRuleBuilderInitial
  ```
  ```cs
  public IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>( ... )
  public interface IRuleBuilderInitial<T, out TProperty> : IRuleBuilder<T, TProperty> { }
  ```

```cs
public static class CustomValidators
{
    public static IRuleBuilderOptionsConditions<T, IList<TElement>> ListMustContainNumberOfItems<T, TElement>(
        this IRuleBuilder<T, IList<TElement>> ruleBuilder, int? min = null, int? max = null)
    {
        return ruleBuilder.Custom((list, context) =>
        {
            if (min.HasValue && list.Count < min.Value)
            {
                context.AddFailure(
                    $"The list must contain {min.Value} items or more. It contains {list.Count} items.");
            }

            if (max.HasValue && list.Count > max.Value)
            {
                context.AddFailure(
                    $"The list must contain {max.Value} items or fewer. It contains {list.Count} items.");
            }
        });
    }
}
```

## WebApi 통합 테스트
```cs

[UsesVerify]
public partial class StudentControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public StudentControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
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
```
```
The list must contain 1 items or more. It contains 0 items.
```