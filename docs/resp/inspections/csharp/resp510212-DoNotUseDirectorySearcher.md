---
title: DirectorySearcher is used
id: resp510212
---

## Description
Do not use DirectorySearcher class to query ActiveDirectory.

## Resolution
Consider SPUtility.GetPrincipalsInGroup method to perform necessary queries.

## Links
- [SPUtility.GetPrincipalsInGroup Method](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.utilities.sputility.getprincipalsingroup(v=office.14).aspx)
