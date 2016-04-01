---
Title: UTC time is used
FileName: resp510253.html
---

### Description
SharePoint web site (SPWeb) has it own regional settings with time zone, independent from Windows. You need to consider site regional settings in all datetime conversion procedures.

Do not use:

- method TimeZoneInfo.ConvertTimeToUtc()
- method DateTime.ToUniversalTime()

### Resolution

Use SPWeb.RegionalSettings.TimeZone.LocalTimeToUTC(your time)

### Links
- [SPTimeZone.LocalTimeToUTC method](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.sptimezone.localtimetoutc.aspx)