---
Title: Use try-catch for SPFile.Exists
FileName: resp510250.html
---

### Description
Although it may seem intuitive that accessing the SPFile.Exists property would return True or False, in fact, if a file doesn’t exist, it throws an ArgumentException error.

### Resolution
Put SPFile.Exists into try-catch block.

<a href="_samples/PutSPFileExistsIntoTryCatchBlock-CorrectSPFileExistsUsage.sample-ref"></a>

### Links
- [SPFile.Exists Property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spfile.exists.aspx)