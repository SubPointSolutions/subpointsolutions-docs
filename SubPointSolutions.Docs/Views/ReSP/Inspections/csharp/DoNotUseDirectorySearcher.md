---
Title: DirectorySearcher is used
FileName: resp510212.html
---

### Description
Do not use DirectorySearcher class to query ActiveDirectory.

### Resolution
Consider SPUtility.GetPrincipalsInGroup method to perform necessary queries.

### Links
- [SPUtility.GetPrincipalsInGroup Method](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.utilities.sputility.getprincipalsingroup(v=office.14).aspx)