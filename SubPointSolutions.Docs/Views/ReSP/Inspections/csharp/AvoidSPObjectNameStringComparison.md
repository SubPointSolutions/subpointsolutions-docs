---
Title: Unsafe SPObject.Name == <string> comparison
FileName: resp510235.html
---

### Description
Depending on the case, SPObject.Name string based comparison is quite unsafe and might lead to the potential issues. In case of loop the result is performance degradation.

The following properties are checked:

- [SPPersistedObject.Name](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.administration.sppersistedobject.name.aspx)
- [SPContentType.Name](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spcontenttype.name.aspx)
- [PageLayout.Name](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.publishing.pagelayout.name.aspx)
- [SPListItem.Name](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.splistitem.name.aspx)
- [TaxonomyItem.Name (perform Group and Term checks)](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.taxonomy.taxonomyitem.name.aspx)
- [SPWeb.Name](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spweb.name.aspx)
- [SPPrincipal.Name](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spprincipal.name.aspx)

<a href="_samples/AvoidSPObjectNameStringComparison-InappropriateComparison.sample-ref"></a>

### Resolution
- Use Object.ID instead or other key property
- Git rid of string comparison in loop

### Links
No links are provided.