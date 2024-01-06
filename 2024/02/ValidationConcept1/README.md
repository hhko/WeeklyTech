# 2024년 Weekly #02 | 유효성 검사는 매핑입니다(개념 1/3)

![](./.images/2024-01-07-03-48-38.png)

> Validation is the process of **mapping a set onto its subset**.  
> 유효성 검사는 큰 집합에서 작은 집합으로 매핑하는 것입니다.
>
> - External world -> Internal world
>   - 큰집하에서 작은 집합으로 이동할 때 유효성 감사를 진행합니다.
> - Internal world -> External world
>   - 작읍 집합에서 큰 집합으로 이동할 때는 유효성 검사를 진행하지 않습니다.

## Validation 성공일 때
```shell
External world      --Validation-> Internal world              --No Validation--> External World
Superset                           Subset                                         Superset
Not-always-valid                   Always-valid domain model                      Not-always-valid
```
```
예. Email
External world      --Validation-> Internal world              --No Validation--> External World
hello@xyz.com                      hello@xyz.com                                  hello@xyz.com
```
- Validation으로 **도메인 모델은 항상 유효합니다(Always-valid domain model)**.
  - Internal world에서는 객체가 유효한지 매번 확인할 필요가 없습니다.

## Validation 실패일 때
```
External world      --Validation------------------------------------------------> External World
Superset                                                                          Superset
Not-always-valid                                                                  Not-always-valid
```
```
예. Email
External world      --Validation------------------------------------------------> External World
hello.com                                                                         hello.com
```

