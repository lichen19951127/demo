%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe %~dp0WindowsService1.exe
Net Start MyWindowsServer
sc config MyWindowsServer start= auto
pause