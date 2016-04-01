---
Title: Static SP-object used as field
FileName: resp510234.html
---

### Description
Avoid having SPite, SPWeb, SPList, SPFile, SPFolder, SPListItem as static field inside classes.

First of all, having a SPSite, SPWeb objects as static fields may cause a memory leak. You should open them as late as possible and dispose them as early as possible.

Second, about SPList, SPFile, SPFolder and SPListItem. All of these objects have link to owner web object, direct or through one related object – it is SPWeb object on which they were created. When the owner web is disposed, the SPList and SPListItem objects created from that web, cannot be used any longer.

### Resolution
Pass SP–object as a method parameter.

### Links
No links are provided.