---
Title: SPListItem.File is used
FileName: resp510226.html
---

### Description
For non document library it returns null.

### Resolution
Check that you work with document library. Use SPWeb.GetFile(SPListItem.UniqueId) instead.

<a href="_samples/AvoidUsingSPListItemFile-AppropriateSPListItemSPFileUsage.sample-ref"></a>

### Links
- [SPListItem.File property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.splistitem.file.aspx)