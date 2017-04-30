---
Title: Avoid SPWeb.Properties usage
FileName: resp510240.html
---
### Description
It’s important to note that the methods of SPWeb that handle properties, reflect upon the SPWeb.AllProperties property and not on the SPWeb.Properties property. Only the AllProperties property should be used, the Properties property is added to SharePoint 2010 in order to provide backwards compatibility with older applications.
SPWeb.Properties is a StringDictionary, and doesn’t support casing for keys/values (everything gets converted to fully lowercase).

### Resolution
Instead of working directly with the SPWeb.Properties, SharePoint 2010 provides SPWeb.AllProperties collection. Although SPWeb.AllProperties is not supported in Sandbox, you can read/write to the property bag through four methods below:

- **SPWeb.GetProperty(Object key)** This method retrieves the value of the specified property from the AllProperties property that is a key/value pair.
- **SPWeb.AddProperty(Object key, Object value)** This method adds a property to the AllProperties property that is a key/value pair.
- **SPWeb.SetProperty(Object key, Object value)** This method updates the value of the specified property in the AllProperties property.
- **SPWeb.DeleteProperty(Object key)** This method deletes a property from the AllProperties property that is a key/value pair.

Don’t let the “object” method signature fool you. After adding a boolean value to SPWeb.AllProperties, but when it was later retrieved, it return back as a String instead of a boolean. It’s definitely good to keep in mind that AllProperties might not accept your complex custom object type.
As a final note, just like any other property of SPWeb, you need to call SPWeb.Update() in order to persist the changes to the underlying database and AllProperties is no different, so don’t forget to do so.

### Links
- [SPWeb.AllProperties Property](http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spweb.allproperties(v=office.14).aspx)
- [Get and set property bag values in SharePoint 2013 apps using CSOM](http://sureshpydi.blogspot.in/2013/05/set-and-get-property-bag-values-in.html)
- [SharePoint: The Wicked SPWeb.Properties PropertyBag](http://trentacular.com/2009/06/sharepoint-the-wicked-spwebproperties-propertybag/)
