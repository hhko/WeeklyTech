# WeeklyTech
> 배움은 설렘이다.
> 주간으로 설렘을 추억한다.

## 2024년
- [#01](./2024/2024-01.md) 로그 수집하기
  ```
  fluent-bat -> otel-collector -> data-prepper -> opensearch -> opensearch dashboards
  ```

## TODO 로그
- 아파치 로그 자동 생성기
- otel-collector 로그 해석하기
  - https://github.com/open-telemetry/opentelemetry-collector-contrib/tree/main/receiver/filelogreceiver
  - https://medium.com/hepsiburadatech/fluent-logging-architecture-fluent-bit-fluentd-elasticsearch-ca4a898e28aa
- otel-collector Windows 로그 해석하기
  - https://github.com/open-telemetry/opentelemetry-collector-contrib/tree/main/receiver/windowseventlogreceiver  
- 컨테이너 로그
- syslog 로그
- OpenSearch Exporter
  - https://github.com/open-telemetry/opentelemetry-collector-contrib/tree/main/exporter/opensearchexporter

```
log.json -> otel-collector -> opensearch -> opensearch dashboards
```