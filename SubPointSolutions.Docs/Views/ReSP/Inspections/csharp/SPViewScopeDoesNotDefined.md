---
Title: SPView.Scope is missed
FileName: resp510205.html
---
### Description
How do we know what people want – folder, inside folder, or just items?
SPView has an "affected scope". It can be one of the follow: 

* Default, Show only the files and subfolders of a specific folder.
* Recursive, Show all files of all folders.
* RecursiveAll, Show all files and all subfolders of all folders.
* FilesOnly, Show only the files of a specific folder.

All enumeration values are covered all possible developer’s intentions. Other words, without specified, SharePoint will use Default value. It is not always correspond develepers needs now or later espetially in case of new folder added. Notify about missing Scope we give developer change to specify it’s architecture approach.

<a href="_samples/SPViewScopeDoesNotDefined-CorrectSPViewScopeUsage.sample-ref"></a>

### Resolution
Consider setting up SPView.Scope property.

### Links
- [SPViewScope enumeration](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spviewscope.aspx)
