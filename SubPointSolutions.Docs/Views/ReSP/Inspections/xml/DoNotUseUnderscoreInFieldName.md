---
Title: Avoid underscore in field name
FileName: resp515108.html
---
### Description
The issue is that SharePoint Online (Office 365) out of the blue has decided to take the spaces and underscores out of the list and variable names while sending the data back to your application. When we send a query using the list and field names, it does get the correct data from the correct list but when it brings the data back, it changes the names of the fields. For example, if I queried against "First_Name", in my "People Demographics" list, it will go and fetch the data but bring it back as "FirstName" rather than "First_Name" and it will have the list name as "PeopleDemographics" rathern than "People Demographics". This could effectively broken all your mappings for all the variables that have an underscore in their names. What is worst is that you will not know if it is a permanent change or just a hiccup.

Also consider the following article to implement correct mappings.
- [Automatically Generated Managed Properties in SharePoint 2010 and 2013](http://www.hersheytech.com/Blog/SharePoint/tabid/197/entryid/37/Default.aspx)

### Resolution
Remove spaces and underscore in Name or StaticName attributes.

### Links
- [Field Element](http://msdn.microsoft.com/en-us/library/office/aa979575.aspx)