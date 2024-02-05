# WeeklyTech
> **배움**은 **설렘**이다.  
> **배움**은 **겸손**이다.  
> **배움**은 **이타심**이다.

- [아키텍처 워크숍 for Domain-Driven Design](https://github.com/hhko/ArchiWorkshop)

## 2024년
### 6주
- WebApi | [WebApi Versioning](./2024/06_2024-02-05/WebApiVersioning/)
  ```
  var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
  {
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"),
        new UrlSegmentApiVersionReader());
  });
  ```

### 5주
- Telemetry | [OpenTelemetry Collector로 Host Metrics 수집하기](./2024/05/Otel-Collector_HostMetrics/)
  ```yaml
  receivers:
    hostmetrics:
      collection_interval: 30s
      scrapers:
        cpu:
        memory:
  ```
- Telemetry | [OpenTelemetry Collector로 Json 로그 수집하기](./2024/05/Otel-Collector_JsonLogs/)
  ```yaml
  # 2024-01-29T11:41:48.3602090+09:00
  # -> Timestamp: 2024-01-29 02:41:48.360209 +0000 UTC
  receivers:
    filelog:
      operators:
      - type: json_parser
        timestamp:
          parse_from: attributes.Timestamp    # 대소문자를 비교한다.
          layout_type: gotime                 # Go언어 기반 파싱
          layout: '2006-01-02T15:04:05.999999999Z07:00'
  ```

### 4주
- ValueObject | [Enumeration 값 객체 만들기(IEnumerable 객체 생성하기)](./2024/04/CreateEnumFormClass/)
  ```cs
  public static IEnumerable<TEnum> GetFieldsForType(Type enumType)
  {
    return enumType
      // public static 필드 검색
      // 모든 상위 타입에 대해 멤버를 검색
      .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
      // enumType과 할당 호환되는 필드만 선택
      .Where(fieldInfo => enumType.IsAssignableFrom(fieldInfo.FieldType))
      // 생성
      .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);
  }
  ```
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
- Validation | [유효성 검사 규칙은 도메인 지식이다(개념 2/3)](./2024/02/ValidationConcept2/)
  ```
  Invariant is a condition that your domain model must uphold at all times.
  Invariant is the same as input validation
  ```
- Validation | [유효성 검사는 하위 집합 매핑이다(개념 1/3)](./2024/02/ValidationConcept1/)
  ```
  Outside World ------------------mapping------------------> Inside World
  Superset                                                   Subset
  Not always-valid domain model                              Always-valid domain model
  제약 조건이 없는 외부 세상                                   제약 조건이 있는 내부 세상
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
