# 2024년 Weekly #05 | OpenTelemetry Collector로 Host Metrics 수집하기

```yaml
receivers:
  hostmetrics:
    collection_interval: 30s
    scrapers:
      cpu:
      memory:

processors:
  batch:

exporters:
  debug:
    verbosity: detailed

service:
  pipelines:
    metrics:
      receivers: [hostmetrics]
      processors: [batch]
      exporters: [debug]
```
- https://github.com/open-telemetry/opentelemetry-collector-contrib/tree/main/receiver/hostmetricsreceiver