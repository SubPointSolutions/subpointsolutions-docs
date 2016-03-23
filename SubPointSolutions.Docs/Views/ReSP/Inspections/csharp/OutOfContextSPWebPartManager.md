---
Title: SPWebPartManager is used while HTTPContext is null
FileName: resp510249.html
---

### Description
SharePoint supports a custom implementation of WebPartManager named SPWebPartManager. In addition, there is an SPLimitedWebPartManager class that supports environments that have no HttpContext or Page available.

### Resolution
If you have HttpContext then use SPWebPartManager. When no HttpContext (in event receivers for example) is available you should use SPLimitedWebPartManager. It only supports a subset of features available in SPWebPartManager.

### Links
- [SPLimitedWebPartManager class](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webpartpages.splimitedwebpartmanager.aspx)
