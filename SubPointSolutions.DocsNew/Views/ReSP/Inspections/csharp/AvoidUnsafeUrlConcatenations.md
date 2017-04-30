---
Title: Unsafe url concatenation
FileName: resp510228.html
---


### Description
Url property for SPSite, SPWeb and SPFolder may return string with or without trailing slash.

### Resolution
Use SPUtility.ConcatUrls/SPUrlUtility.CombineUrl methods instead.

### Links
- [SPUtility.ConcatUrls Method](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.utilities.sputility.concaturls(v=office.14).aspx)
- [SPUrlUtility.CombineUrl method](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.utilities.spurlutility.combineurl(v=office.14).aspx)
- [Working with URL’s in SharePoint](http://blog.hompus.nl/2009/03/09/working-with-urls-in-sharepoint/)