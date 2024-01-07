# 2024년 Weekly #02 | 유효성 검사는 하위 집합 매핑이다(개념 1/3)

![](./.images/2024-01-07-03-48-38.png)

> Validation is the process of **mapping a set(superset) onto its subset**.  
> 유효성 검사는 집합을 하위 집합에 매핑하는 절차입니다.
>
> - `External world --Validation--> Internal world`
>   - 집합을 하위 집합에 매핑할 때 유효성 감사를 진행합니다.
> - `Internal world --No Validation--> External world`
>   - 하위 집합을 집합에 매핑할 때 유효성 검사를 진행하지 않습니다.

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
- Validation 실패일 때는 유효하지 않기 때문에 Internal world 도메인 모델을 생성하지 않습니다.
