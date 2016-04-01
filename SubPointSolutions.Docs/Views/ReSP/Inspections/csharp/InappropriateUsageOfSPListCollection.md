---
Title: Inappropriate SPList collection usage
FileName: resp510209.html
---

### Description
List name is culture specific string or could be changed later:

- Avoid string based index calls to obtain the list.
- Avoid using TryGetList method for the List access.

Potential performance issues:

- Avoid all list enumerations via enumerator calls.
- Avoid all list enumerations via linq Cast<T> expression.
- Avoid all list enumerations via linq OfType<T> expression.

Inappropriate usage:

<img title="code.png" src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=spcafcontrib&amp;DownloadId=831767" alt="code.png">

### Resolution
Consider retrieving list by its URL with [SPWeb.GetList() method](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.getlist.aspx)

<a href="_samples/InappropriateUsageOfSPListCollection-CorrectListUsage.sample-ref"></a>

### Links
- [SPWeb.GetList() method](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.getlist.aspx)