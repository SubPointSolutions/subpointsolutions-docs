---
title: SPListItem.File is used
id: resp510226
---

## Description
For non document library it returns null.

## Resolution
Check that you work with document library. Use SPWeb.GetFile(SPListItem.UniqueId) instead.

```cs
var file = item.Web.GetFile(item.UniqueId);
```

## Links
- [SPListItem.File property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.splistitem.file.aspx)
