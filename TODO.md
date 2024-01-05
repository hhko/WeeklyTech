## TODO 로그
- https://opentelemetry.io/docs/specs/otel/logs/
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