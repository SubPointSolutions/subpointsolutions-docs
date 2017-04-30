---
Title: SPGridView.AutoGenerateColumns in page
FileName: resp516905.html
---

###  Description
SPGridView control does not support the automatic generation of columns.

###  Resolution
You always have to set the property AutoGenerateColumns to false and explicitly bind your columns using SPBoundField.

###  Links
- [SPGridView class](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.spgridview.aspx)
- [Using SPGridView to bound to list data in SharePoint](http://nishantrana.me/2009/03/23/using-spgridview-to-bound-to-list-data-in-sharepoint/)