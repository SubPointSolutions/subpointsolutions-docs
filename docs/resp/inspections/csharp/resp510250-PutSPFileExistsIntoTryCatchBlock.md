---
title: Use try-catch for SPFile.Exists
id: resp510250
---

## Description
Although it may seem intuitive that accessing the SPFile.Exists property would return True or False, in fact, if a file doesn’t exist, it throws an ArgumentException error.

## Resolution
Put SPFile.Exists into try-catch block.

```cs
var defaultMasterUrl = "/_catalogs/masterpage/default.master";
 
if (web.AllProperties.ContainsKey("OldMasterUrl"))
{
    string oldMasterUrl = web.AllProperties["OldMasterUrl"].ToString();
    try
    {
        var fileExists = web.GetFile(oldMasterUrl).Exists;
        web.MasterUrl = oldMasterUrl;
    }
    catch (ArgumentException)
    {
        web.MasterUrl = defaultMasterUrl;
    }
 
 
    var oldCustomUrl = web.AllProperties["OldCustomMasterUrl"].ToString();
    try
    {
        var fileExists = web.GetFile(oldCustomUrl).Exists;
        web.CustomMasterUrl = web.AllProperties["OldCustomMasterUrl"].ToString();
    }
    catch (ArgumentException)
    {
        web.CustomMasterUrl = defaultMasterUrl;
    }
 
    web.AllProperties.Remove("OldMasterUrl");
    web.AllProperties.Remove("OldCustomMasterUrl");
}
else
{
    web.MasterUrl = defaultMasterUrl;
    web.CustomMasterUrl = defaultMasterUrl;
}
```

## Links
- [SPFile.Exists Property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spfile.exists.aspx)
