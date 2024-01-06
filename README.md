# WeeklyTech
> **배움**은 **설렘**이다.  
> 주간으로 설렘을 기록한다.

## 2024년
### 2주
- `TODO` FluentValidation | Entity 유효성 검사 통합
- `TODO` Telemetry | otel-collector 로그 파일 모니터링

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