# WeeklyTech
> **배움**은 **설렘**이다.  
> **배움**은 **겸손**이다.  
> **배움**은 **이타심**이다.

- [아키텍처 워크숍 for Domain-Driven Design](https://github.com/hhko/ArchiWorkshop)

## 2024년
### 3주
- CI/CD | [GitHub Actions 코드 커버리지](./2024/03/GitHubCodeCoverage/)
  ```
  .github/workflows/{파일명}.yml
  ```
- CI/CD | [로컬 코드 커버리지](./2024/03/LocalCodeCoverage/)
  ```
  패키지 ID                              버전           명령
  --------------------------------------------------------------------
  dotnet-coverage                        17.9.6        dotnet-coverage
  dotnet-reportgenerator-globaltool      5.2.0         reportgenerator
  ```

### 2주
- Validation | [유효성 검사는 하위 집합 매핑이다(개념 1/3)](./2024/02/ValidationConcept1/)
  ```
  Outside World ------------------mapping------------------> Inside World
  Superset                                                   Subset
  Not always-valid domain model                              Always-valid domain model
  제약 조건이 없는 외부 세상                                   제약 조건이 있는 내부 세상
  ```
- Validation | [유효성 검사 규칙은 도메인 지식이다(개념 2/3)](./2024/02/ValidationConcept2/)
  ```
  Invariant is a condition that your domain model must uphold at all times.
  Invariant is the same as input validation
  ```

### 1주
- Telemetry | [로그 수집 시스템 구축하기](./2024/01/TelemetryLogSystem/)
  ```
  fluent-bat
    -> {otel-collector}
    -> data-prepper
    -> opensearch
    -> opensearch dashboards
  ```
- Validation | [FluentValidation 확장 메서드 만들기](./2024/01/FluentValidationExtensionMethod/)
  ```cs
  IRuleBuilder<T, IList<TElement>> ruleBuilder
  ```
