---
Title: Consider Overwrite='TRUE' for field
FileName: resp515104.html
---
### Description
Fields with Overwrite=”TRUE” are deployed directly to Content Database and not subject to ghosting issues.

### Note
- The rule does not check content types in List Schema.

### Resolution
Add Overwrite="TRUE" attribute.

### Links
- [Field Element](https://msdn.microsoft.com/en-us/library/office/aa979575(v=office.14).aspx)
- [How logic flaws in SharePoint Element activation process can break Lookup fields](http://www.codefornuts.com/2010/12/how-logic-flaws-in-sharepoints-element.html)
- [Add SharePoint lookup column declaratively through CAML XML](http://blogs.msdn.com/b/joshuag/archive/2008/03/14/add-sharepoint-lookup-column-declaratively-through-caml-xml.aspx)