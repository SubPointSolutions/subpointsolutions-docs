---
title: Inappropriate SPList collection usage
id: resp510209
---

## Description
List name is culture specific string or could be changed later:

- Avoid string based index calls to obtain the list.
- Avoid using `.TryGetList` method for the List access.

Potential performance issues:

- Avoid all list enumerations via enumerator calls.
- Avoid all list enumerations via linq `.Cast<T>` expression.
- Avoid all list enumerations via linq `.OfType<T>` expression.

## Resolution
Consider retrieving list by its URL with [SPWeb.GetList() method](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.getlist.aspx)

```cs
var listUrl = "/lists/tasks";
var taskList = web.GetList(SPUrlUtility.CombineUrl(web.Url, listUrl));
```

## Links
- [SPWeb.GetList() method](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.getlist.aspx)
