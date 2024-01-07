- `TODO` FluentValidation | Entity 유효성 검사 통합
- `TODO` Telemetry | otel-collector 로그 파일 모니터링

## TODO 로그 목표
```
file -> otel-collector -> data-prepper -> opensearch -> opensearch dashboards
                       -> vector       ->
```
- file
  - json
  - syslog
  - windows log
  - container log
- 로그 자동 생성기

### 참고 자료
- https://opentelemetry.io/docs/specs/otel/logs/
- 아파치 로그 자동 생성기
- otel-collector 로그 해석하기
  - https://github.com/open-telemetry/opentelemetry-collector-contrib/tree/main/receiver/filelogreceiver
  - https://medium.com/hepsiburadatech/fluent-logging-architecture-fluent-bit-fluentd-elasticsearch-ca4a898e28aa
- otel-collector Windows 로그 해석하기
  - https://github.com/open-telemetry/opentelemetry-collector-contrib/tree/main/receiver/windowseventlogreceiver
- OpenSearch Exporter
  - https://github.com/open-telemetry/opentelemetry-collector-contrib/tree/main/exporter/opensearchexporter
- vector docker-compose
  - https://github.com/livingdocsIO/monitoring

## TODO
- global.json
- Directory.Build.props
- Directory.Packages.props
- .editorconfig
