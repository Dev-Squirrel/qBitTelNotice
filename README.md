## 어떤 프로그램인가요?
[SQLite](https://www.sqlite.org/)를 사용하여 만든 [qBittorrent](https://www.qbittorrent.org/) 토렌트 다운로드 완료 [Telegram](https://telegram.org/) 알림 프로그램입니다.

VS2015로 개발 되었고 빌드에는 [NuGet 패키지 매니저](https://www.nuget.org/)가 필요합니다.

## 봇이 할 수 있는 일은 무엇일까요?
qBittorrent 프로그램을 통해 다운로드가 완료 될 경우 텔레그램 채팅방으로 메시지를 전달합니다.

## 텔레그램 봇에 사용 될 토큰은 어디서 구하나요?
밑에 링크를 참조하여 발급 받은 토큰을 BOT_Token.txt 안에 넣어주시면 됩니다.

https://core.telegram.org/bots#6-botfather

## 텔레그램 봇에 사용 될 ChatID는 어디서 구하나요?
밑에 글을 참조하여 Chat_Id.txt 안에 넣어주시면 됩니다.

01. 봇을 먼저 초대하여 말을 걸어 주세요.

02. 위에서 발급 받은 BOT 토큰을 밑에 주소에 넣어 접속하세요.<br />
https://api.telegram.org/bot[여기에 토큰 입력]/getUpdates<br />
 - 예) https://api.telegram.org/bot110201543:AAHdqTcvCH1vGWJxfSeofSAs0K5PALDsaw/getUpdates

03. 밑에 "!!!!여기에값!!!!" 이라고 적힌 부분이 chat id 입니다.<br />
\{"ok":true,"result":[{"update_id":11111111,
"message":{"message_id":185,"from":{"id":"!!!!여기에값!!!!","first_name":"퍼스트네임","username":"닉네임","language_code":"ko-KR"},"chat":{"id":12345567,"first_name":"닉네임","username":"닉네임","type":"private"},"date":1502128812,"text":"aaaaaaa"}}]\}

## qBittorrent에서 어떻게 설정하나요?
01. 도구(T) - 옵션(O) 또는 Alt+O 바로 가기 키로 옵션창으로 이동합니다.

02. 다운로드 탭에서 제일 밑에 "토런트 완료시 외부 프로그램 실행" 체크를 하시고 qBitTelNotice.exe 경로를 넣어주시면 됩니다.<br />
 - 예) C:\Users\\[username]\Desktop\qBitTelNotice\qBitTelNotice.exe "Torrent DL : %N"

자세한 세부 옵션은 "지원되는 변수 (대소문자 구분)" 참조하시면 됩니다.

## LICENSE
MIT License

Copyright (c) 2018 Dev-Squirrel