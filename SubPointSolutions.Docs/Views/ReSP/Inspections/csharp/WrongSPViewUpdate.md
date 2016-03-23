---
Title: Incorrect SPView usage
FileName: resp510247.html
---
### Description
SPList.DefaultView and SPList.Views[] properties return a new SPView instance with every call. To handle a single instance you need to retrieve the SPView object and modify it directly.

Incorrect usage:
[TEST.IncorrectSPViewUpdate]

Correct usage:
[TEST.CorrectSPViewUpdate]

### Links
- [SPView.Update() method](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spview.update.aspx)

