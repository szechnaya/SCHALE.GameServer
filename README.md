# SCHALE.GameServer

## Prerequisites

- Some computer knowledge
- [.NET SDK 8.0](https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0)
- [SQL Express](https://www.microsoft.com/zh-tw/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/zh-tw/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- [LD Player 9](https://www.ldplayer.tw/)
- [Python](https://www.python.org/)

## Steps

1. Start SQL server
2. Start private game server
3. Start LD Player
4. Start Mitmproxy
5. Make sure Wireguard is on
6. Start ブルアカ
7. Enjoy :smile:

### SQL server

Use SSMS to connect with default settings except that you have to check "Trust server certificate".

### Game server

```bash
# in this repo
cd SCHALE.GameServer
dotnet run
```

### Mitmproxy

```bash
# in this repo
cd Scripts\redirect_server_mitmproxy
# Replace x.x.x.x with your ipv4/ Server Address
mitmweb -m wireguard --no-http2 -s redirect_server.py --set termlog_verbosity=warn --ignore x.x.x.x
```


