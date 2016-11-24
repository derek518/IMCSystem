%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe IMCSystem.Server.exe
Net Start IMCService
sc config IMCService start= auto