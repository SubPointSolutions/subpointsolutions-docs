---
Title: SPContext.Current is used outside web context
FileName: resp510222.html
---


### Description
Avoid using SPContext.Current outside of web request context.

### Resolution
Pass SPWeb/SPSite object as parameter of method.

### Links
- [SPContext.Current Property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spcontext.current(v=office.14).aspx)