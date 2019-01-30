---
title: Incorrect SPView usage
id: resp510247
---
## Description
SPList.DefaultView and SPList.Views[] properties return a new SPView instance with every call. To handle a single instance you need to retrieve the SPView object and modify it directly.

Incorrect usage:
```cs
// won't save view (!!!)
list.Views["TestView1"].DefaultView = true;
list.Views["TestView1"].Update();
 
// saves the "NewField2" only (!!!)
list.DefaultView.ViewFields.Add("NewField1");
list.DefaultView.ViewFields.Add("NewField2");
list.DefaultView.Update();
```

Correct usage:
```cs
// save SPView instance into a local varible, always!
var view = list.Views["TestView1"];
 
view.DefaultView = true;
view.Paged = true;
 
view.Update();
```

## Links
- [SPView.Update() method](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spview.update.aspx)

