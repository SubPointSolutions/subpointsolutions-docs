---
Title: Inappropriate PublishingWeb.GetPublishingPages() usage
FileName: resp510232.html
---
### Description
There are two methods GetPublishingPages() and GetPublishingPages(uint rowLimit). 

Both methods lead to the following issues:
- performance degradation
- they return items from the root folder – if you have folders, you don’t get anything inside folders

### Resolution
Use GetPublishingPages(SPQuery query) or GetPublishingPages(string camlQuery) methods.


### Links
- [GetPublishingPages()](https://msdn.microsoft.com/en-us/library/ms493244.aspx)
- [GetPublishingPages(string camlQuery)](https://msdn.microsoft.com/en-us/library/ms559808.aspx)
- [GetPublishingPages(uint rowLimit)](https://msdn.microsoft.com/en-us/library/ms571021.aspx)