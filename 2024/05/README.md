# 2024년 Weekly #05 | OpenTelemetry Collector Json 로그 읽기

## 다운로드
- https://github.com/open-telemetry/opentelemetry-collector-releases/releases
  - https://github.com/open-telemetry/opentelemetry-collector-releases/releases/download/v0.92.0/otelcol-contrib_0.92.0_windows_amd64.tar.gz

## Json 로그 입력
```json
{"Timestamp":"2024-01-29T11:41:48.3602090+09:00","Level":"Warning","MessageTemplate":"The ASP.NET Core developer certificate is not trusted."}
```

## Josn 로그 출력
```
ObservedTimestamp: 2024-01-29 05:34:45.8815265 +0000 UTC
Timestamp: 2024-01-29 02:41:48.360209 +0000 UTC
SeverityText: Warning
SeverityNumber: Warn(13)
Body: Str({"Timestamp":"2024-01-29T11:41:48.3602090+09:00","Level":"Warning","MessageTemplate":"The ASP.NET Core developer certificate is not trusted."})
Attributes:
     -> Level: Str(Warning)
     -> MessageTemplate: Str(The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert.)
     -> Properties: Map({"EnvironmentName":"Staging","EnvironmentUserName":"DESKTOP-FAOR0RM\\hyungho.ko","EventId":{"Id":8,"Name":"DeveloperCertificateNotTrusted"},"MachineName":"DESKTOP-FAOR0RM","ProcessId":15984,"ProcessName":"ArchiWorkshop","SourceContext":"Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServer","ThreadId":1})
     -> log.file.name: Str(sample.json)
     -> Timestamp: Str(2024-01-29T11:41:48.3602090+09:00)
```

## Json 로그 Pipeline
```yaml
receivers:


  # 참고 자료
  #   https://github.com/open-telemetry/opentelemetry-collector-contrib/tree/main/receiver/filelogreceiver
  #   https://seankhliao.com/blog/12021-06-17-opentelemetry-collector-logs/
  filelog:
    include:
      - C:\ ... \otelcol-contrib_0.92.0_windows_amd64\sample.json
    start_at: beginning
    include_file_name: false
    operators:
      - type: json_parser

        # 원본 데이터
        #   Attributes:
        #     -> Timestamp: Str(2024-01-29T11:41:48.3602090+09:00)
        # 데이터
        #   Timestamp: 2024-01-29 02:41:48.360209 +0000 UTC
        #
        # 참고 자료
        #   https://github.com/open-telemetry/opentelemetry-collector-contrib/blob/main/pkg/stanza/docs/types/timestamp.md
        timestamp:
          parse_from: attributes.Timestamp    # 대소문자를 비교한다.
          layout_type: gotime                 # Go언어 기반 파싱
          #layout: '2006-01-02T15:04:05Z07:00'
          layout: '2006-01-02T15:04:05.999999999Z07:00'

        # 원본 데이터
        #   Attributes:
        #     -> Level: Str(Warning)
        # 데이터
        #   SeverityText: Warning
        #   SeverityNumber: Warn(13)
        #
        # 참고 자료
        #   https://github.com/open-telemetry/opentelemetry-collector-contrib/blob/main/pkg/stanza/docs/types/severity.md
        severity:
          parse_from: attributes.Level        # 대소문자를 비교한다.
          mapping:
            warn: warning                     # 대소문자를 비교하지 않는다.

processors:
  batch:

exporters:
  debug:
    verbosity: detailed

service:
  pipelines:
    logs:
      receivers: [filelog]
      processors: [batch]
      exporters: [debug]
```
