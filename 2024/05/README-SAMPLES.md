## 실행
```
.\otelcol-contrib.exe --config=file:C:\ ... \config.yaml
.\otelcol-contrib.exe --config=file:.\config.yaml
.\otelcol-contrib.exe --config=.\config.yaml
```

## filelog parse 예제
### 2024-01-29T11:41:48.3602090+09:00 형식
```json
{"Timestamp":"2024-01-29T11:41:48.3602090+09:00","Level":"Warning","MessageTemplate":"The ASP.NET Core developer certificate is not trusted."}
```
```
ObservedTimestamp: 2024-01-29 05:56:22.3336086 +0000 UTC
Timestamp: 2024-01-29 02:41:48.360209 +0000 UTC
SeverityText: Warning
SeverityNumber: Warn(13)
Body: Str({"Timestamp":"2024-01-29T11:41:48.3602090+09:00","Level":"Warning","MessageTemplate":"The ASP.NET Core developer certificate is not trusted."})
Attributes:
     -> Timestamp: Str(2024-01-29T11:41:48.3602090+09:00)
     -> Level: Str(Warning)
     -> MessageTemplate: Str(The ASP.NET Core developer certificate is not trusted.)
```
```yaml
receivers:
  filelog:
    include:
      - C:\ ... \sample.json
    start_at: beginning                     # 처음부터 로그 파일을 읽는다.
    include_file_name: false                # 파일 이름은 데이터에서 생략한다.
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
          layout_type: gotime                 # Go언어 기반으로 날짜 데이터를 파싱한다.
          layout: 2006-01-02T15:04:05Z07:00

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
```

<br/>

### 2023-06-19 05:20:50 ERROR
```
2023-06-19 05:20:50 ERROR This is a test error message
```
```yaml
receivers:
  filelog:
    include:
      - simple.log
    operators:
      - type: regex_parser
        regex: '^(?P<time>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) (?P<sev>[A-Z]*) (?P<msg>.*)$'
        timestamp:
          parse_from: attributes.time
          layout: '%Y-%m-%d %H:%M:%S'
        severity:
          parse_from: attributes.sev
```

<br/>

### 2021/06/17 22:37:44
```
2021/06/17 22:37:44 Something happened foo=bar
```
```yaml
receivers:
  filelog:
    include:
      - std.log
    operators:
      - type: regex_parser
        regex: "^(?P<timestamp_field>.{19}) (?P<message>.*)$"
        timestamp:
          parse_from: timestamp_field
          layout_type: strptime
          layout: "%Y/%m/%d %T"
```

<br/>

### E0617 22:38:02.013247
```
E0617 22:38:02.013247   76356 main.go:57]  "msg"="something bad happened" "error"="oops"
```
```yaml
receivers:
  filelog:
    include:
      - klog.log
    include_file_name: false
    operators:
      - type: regex_parser
        # Lmmdd hh:mm:ss.uuuuuu threadid file:line]
        regex: '^(?P<level>[EI])(?P<timestamp_field>.{20})\s+(?P<threadid>\d+)\s(?P<file>\w+\.go):(?P<line>\d+)]\s+(?P<message>.*)$'
        timestamp:
          parse_from: timestamp_field
          layout: "%m%d %H:%M:%S.%f"
        severity:
          parse_from: level
          mapping:
            error: E
            info: I
```

<br/>

## 참고 자료
- [Parsing logs with the OpenTelemetry Collector](https://signoz.io/blog/parsing-logs-with-the-opentelemetry-collector/)
