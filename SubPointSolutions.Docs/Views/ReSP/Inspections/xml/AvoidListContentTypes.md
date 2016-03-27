---
Title: Avoid list content types
FileName: resp515201.html
---
### Description
ContentTypeRef is for referencing content type from Site content types.
ContentType is for defining new content type directly in list definition.

The design intention of content types is to support re-use of the list schema (or behaviours). So if there is a requirement to create a lot of lists with the same structure, which is often the case, then the content type enables this. It would be unacceptable to have to create list schemas individually in this situation and would result in repetitive error-prone work. Usually in large SharePoint sites there is a requirement to enforce some level of consistency in the metadata.

In the case where you just create a single list, and you do not anticipate building similar lists elsewhere in the site, there is no reason to use a content type. You can just create an ad-hoc custom list. The same applies to fields – site columns are useful where you want to create consistent metadata across different content types and lists, but not necessary if you don’t have that requirement.

The standard list types are a useful starting point if it makes sense for your custom list. For example a Links list gives you some extra functionality, so if you have something that is more complicated but is, at its core, a list of hyperlinks, this is a good place to start. But there is nothing wrong with creating a custom list if you don’t need this.

### Resolution
Change list content type to ContentTypeRef

<a href="_samples/AvoidListContentTypes-CorrectContentTypesInList.sample-ref"></a>

### Links
- [Site and List Content Types](https://msdn.microsoft.com/en-us/library/office/ms463016(v=office.14).aspx)
