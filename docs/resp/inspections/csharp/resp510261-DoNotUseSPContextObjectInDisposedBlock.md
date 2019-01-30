---
title: SPContext objects are disposed
id: resp510261
---
## Description
SPContext objects are managed by the SharePoint framework and should not be explicitly disposed in your code.

Inappropriate usage:
```cs
using (var site = SPContext.Current.Site)
{
}
```

## Resolution
You need to ensure that you only dispose SPSite and SPWeb objects that your code owns.
```cs
using (var site = new SPSite(SPContext.Current.Site.ID))
{
}
```

This method will ensure that a new independent SPSite object is created which you then can dispose without side effects on other code using the SPSite object bound to the current SPContext object.

## Links
- [Best Practices: Using Disposable Windows SharePoint Services Objects](https://msdn.microsoft.com/en-us/library/aa973248(v=office.12).aspx)
- [Disposing SPWeb and SPSite objects](http://blogs.technet.com/b/stefan_gossner/archive/2008/12/05/disposing-spweb-and-spsite-objects.aspx)
