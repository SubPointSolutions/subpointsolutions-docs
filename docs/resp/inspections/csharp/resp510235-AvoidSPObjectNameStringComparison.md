---
title: Unsafe SPObject.Name == <string> comparison
id: resp510235
---

## Description
Depending on the case, SPObject.Name string based comparison is quite unsafe and might lead to the potential issues. In case of loop the result is performance degradation.

The following properties are checked:

- [SPPersistedObject.Name](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.administration.sppersistedobject.name.aspx)
- [SPContentType.Name](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spcontenttype.name.aspx)
- [PageLayout.Name](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.publishing.pagelayout.name.aspx)
- [SPListItem.Name](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.splistitem.name.aspx)
- [TaxonomyItem.Name (perform Group and Term checks)](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.taxonomy.taxonomyitem.name.aspx)
- [SPWeb.Name](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spweb.name.aspx)
- [SPPrincipal.Name](https://msdn.microsoft.com/en-us/library/office/microsoft.sharepoint.spprincipal.name.aspx)

```cs
var session = new TaxonomySession(site);
var termStore = session.TermStores["Company"];
 
var group = termStore.Groups["HR"];
var termSet = group.TermSets["Review"];
var term = termSet.Terms["Year 2012"];
 
// wrong
if (group.Name != "HR")
{
    // wrong
    if (term.Name != "Review")
    {
        // Do stuff
    }
}
```

## Resolution
- Use Object.ID instead or other key property
- Git rid of string comparison in loop

## Links
No links are provided.
