---
Title: Avoid custom logging
FileName: resp510239.html
---
### Description
Do not use custom logging tools. It is required web.config changes or affects to solution security. Validated tool list:

- EventLog
- NLog
- log4net
- Common Logging
- Enterprise Library Logging Application Block
- ObjectGuy Framework
- C# Logger
- C# .NET Logger
- LogThis
- NetTrace
- NSpring
- Loggr
- ELMAH

### Resolution
Use SPDiagnosticsService class to log.

### Links
- [SPDiagnosticsService Class](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.administration.spdiagnosticsservice(v=office.14).aspx)