---
title: Unsafe cast on SPListItem
id: resp510213
---
## Description
SPListItem is untyped entity, so null reference exceptions on nullable types or wrong type conversion exception might arise.

Incorrect usage:
```cs
string date1 = item["Date"].ToString();
DateTime date2 = (DateTime)item["Date"];
int x = ((SPFieldUserValue)item["User"]).LookupId;
```

## Resolution
Consider Convert.ToXXX method or manual conversion to handle wrong/nullable types.
```cs
DateTime date1 = Convert.ToDateTime(item["Date"]);
DateTime? date2 = item["Date"] as DateTime?;
```

## Links
- [Convert Methods](https://msdn.microsoft.com/en-us/library/system.convert_methods(v=vs.110).aspx)
