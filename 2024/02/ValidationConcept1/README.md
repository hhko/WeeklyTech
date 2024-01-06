# 2024년 Weekly #02 | 유효성 검사는 매핑입니다(개념 1/3)

![](./.images/2024-01-07-03-48-38.png)

> Validation is the process of **mapping a set onto its subset**.  
> 유효성 검사는 큰 집합에서 작은 집합으로 매핑하는 것입니다.

## Validation 성공일 때
```shell
External world      --Validation-> Internal world              --No Validation--> External World
Superset                           Subset                                         Superset
Not-always-valid                   Always-valid domain model                      Not-always-valid
```
```
예. Email
hello@xyz.com       --Validation-> hello@xyz.com               --No Validation--> hello@xyz.com
```
- Validation으로 항상 유효한 도메인 객체 세상이 된다. 

## Validation 실패일 때
```
External world      --Validation------------------------------------------------> External World
Superset                                                                          Superset
Not-always-valid                                                                  Not-always-valid
```
```
예. Email
hello.com           --Validation------------------------------------------------> hello.com
```

