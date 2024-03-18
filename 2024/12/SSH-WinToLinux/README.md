# SSH 접속시 암호 생략하기

```shell
#
# SSH 서버
#

# SSH 서버 설치
Add-WindowsCapability -Online -Name OpenSSH.Server~~~~0.0.1.0
Start-Service sshd
Set-Service -Name sshd -StartupType 'Automatic'

# SSH 서버 방화벽 확인
Get-NetFirewallRule -Name OpenSSH-Server-In-TCP
     Enabled : True
New-NetFirewallRule -Name sshd -DisplayName 'OpenSSH-Server-In-TCP' -Enabled True -Direction Inbound -Protocol TCP -Action Allow -LocalPort 22
whoami

#
# SSH 클라이언트
#

# SSH 클라이언트 설치
Add-WindowsCapability -Online -Name OpenSSH.Client~~~~0.0.1.0

# SSH 서버 접속 확인
ssh {서버 계정}@{whoami 결과 값}

#
# 1. SSH 클라이언트 키 생성 : RSA 기반 형식으로 키 만들기
#   - $env:USERPROFILE\.ssh\id_rsa
#   - $env:USERPROFILE\.ssh\id_rsa.pub
ssh-keygen

#
# 2. SSH 서버 Home 디렉토리에 .ssh 폴더를 생성하기(없다면)
#
ssh {서버 계정}@{서버 이름 | 서버 IP}
mkdir ~\.ssh

#
# 3. SSH 클라이언트 -{복사: Public 키 내용 복사}-> SSH 서버
#   - yes
#   - 로그인 암호 입력
type $env:USERPROFILE\.ssh\id_rsa.pub | ssh {서버 계정}@{서버 이름 | 서버 IP} "cat >> .ssh/authorized_keys"
# 예.
# type $env:USERPROFILE\.ssh\id_rsa.pub | ssh xyz@1.1.1.2 "cat >> .ssh/authorized_keys"

#
# 3. SSH 서버 접속(암호 입력 없음)
#
ssh {서버 계정}@{서버 이름 | 서버 IP}
ssh {서버 계정}@{서버 이름 | 서버 IP} -p {서버 Port}
```
