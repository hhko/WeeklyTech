# 2024년 Weekly #01 | FluentValidation 확장 메서드 만들기

## 개요
- 유효성 검사를 명시적으로 개선한다.
  > 주소는 최소 1개에서 최대 3개를 갖는다.
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
- Verify을 이용하여 WebApi 결과를 Snapshot 테스트한다.

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
### FluentValidation 인터페이스 이해
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

### 배열 유효성 검사 확장 메서드
```cs
IRuleBuilder<T, IList<TElement>>
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

## Verify Snapshot 테스트
### 형상관리 설정
- `.gitignore` 파일
  ```
  *.received.*
  ```
- ``.gitattributes` 파일
  ```
  *.verified.txt text eol=lf working-tree-encoding=UTF-8
  *.verified.xml text eol=lf working-tree-encoding=UTF-8
  *.verified.json text eol=lf working-tree-encoding=UTF-8
  ```

### 출력 경로 지정
```cs
public static class VerifierInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        // https://github.com/VerifyTests/Verify/blob/main/docs/naming.md
        // UseSplitModeForUniqueDirectory 
        UseProjectRelativeDirectory("Snapshots");

        //VerifySourceGenerators.Enable();
    }
}
```

## TODO
- `[Theory]`로 0개, 4개 주소 테스트 필요

## 참고 자료
- [Parameter Passing in IRuleBuilder Extension Method](https://copyprogramming.com/howto/passing-parameter-to-irulebuilder-extension-method)