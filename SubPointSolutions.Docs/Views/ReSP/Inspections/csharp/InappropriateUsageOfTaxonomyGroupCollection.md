---
Title: Inappropriate taxonomy collection usage
FileName: resp510227.html
---

### Description
Avoid string based index call on taxonomy collection because it could be localized or case -sensitive.

The following collections are checked:

- Microsoft.SharePoint.Taxonomy.GroupCollection
- Microsoft.SharePoint.Taxonomy.TermSetCollection
- Microsoft.SharePoint.Taxonomy.TermCollection
- Microsoft.SharePoint.Taxonomy.TermStoreCollection

### Resolution
Consider fetching item by GUID, string comporation by collection enumeration, GetById() or GetByName() methods.

### Links
- [How to translate and localize terms programmatically in sharepoint 2010?](http://sharepoint.stackexchange.com/questions/39667/how-to-translate-and-localize-terms-programmatically-in-sharepoint-2010)
- [IndexedCollection<T>.Item property (Guid)](https://msdn.microsoft.com/en-us/library/office/ee569459.aspx)