---
Title: SPQuery.Scope is missed
FileName: resp510210.html
---
### Description
How do we know what people want – folder, inside folder, or just items?
SPQuery has an “affected scope”. It can be one of the follow: 

* Default, Show only the files and subfolders of a specific folder.
* Recursive, Show all files of all folders.
* RecursiveAll, Show all files and all subfolders of all folders.

All enumeration values are covered all possible developer’s intentions. Other words, without specified, SharePoint will use Default value. It is not always correspond developer needs now or later especially in case of new folder added. Notify about missing ViewAttributes we give developer change to specify it’s architecture approach.
Let compare results of queries with SharePoint list which contains 561 items stored in folders and subfolders.

<a href="_samples/SPQueryScopeDoesNotDefined-SPQueryScopeUsageSamples.sample-ref"></a>

Outcome:
* All Items Count: 561
* First Query: 8
* Second Query: 561

How you can see in first attempting it was only 8 items (root folders only), but in second attempting the result is better so expected 561 items dedicated with two outs according to best practise how to working with large lists.

### Resolution
Consider setting up SPQuery.Scope property.

### Links
- [SPQuery.ViewAttributes property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.viewattributes.aspx)
- [SPViewScope enumeration](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spviewscope.aspx)