---
Title: SPPersistedObject is updated
FileName: resp510243.html
---

### Description
SharePoint 2010+ has security feature to all objects inheriting from SPPersistedObject. This feature explicitly disallows modification of SPPersistedObject objects from content web applications (not CA).

### Resolution

- Rescope your features so that web application related activity are performed by a web application scoped feature. Notice that you cannot use a site scoped feature – this would just throw another Access Denied error.
- Disable the security setting (we won’t suggest this, the security setting was created with a purpose in mind), either via power shell or a console app. target property is "**Microsoft.SharePoint.Administration.SPWebService.ContentService.RemoteAdministratorAccessDenied**"

### Links
- [SPPersistedObject class](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.administration.sppersistedobject.aspx)
- [kb 2564009](https://support.microsoft.com/en-gb/kb/2564009/en-us)
- [The SPPersistedObject, XXXXXXXXXXX, could not be updated because the current user is not a Farm Administrator craziness in Sharepoint 2010](http://unclepaul84.blogspot.ru/2010/06/sppersistedobject-xxxxxxxxxxx-could-not.html)