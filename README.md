# WeeklyTech
> **배움**은 **설렘**이다.  
> 주간으로 설렘을 기록한다.

- [아키텍처 워크숍 for Domain-Driven Design](https://github.com/hhko/ArchiWorkshop)

## 2024년
### 2주
- Validation | [유효성 검사는 하위 집합 매핑이다(개념 1/3)](./2024/02/ValidationConcept1/)
  ```
  Always-valid domain model
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
- FluentValidation | [FluentValidation 확장 메서드](./2024/01/FluentValidationExtensionMethod/)
  ```cs
  IRuleBuilder<T, IList<TElement>> ruleBuilder
  ```