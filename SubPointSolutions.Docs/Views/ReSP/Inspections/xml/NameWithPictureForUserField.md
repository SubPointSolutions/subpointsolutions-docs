---
Title: Incorrect 'ShowField' attr value
FileName: resp515106.html
---
### Description
In SharePoint 2013, if schema.xml contains user field with an attribute **ShowField="NameWithPicture"** it is recommended to replace it with **ShowField="NameWithPictureAndDetails"** attribute.

In SP2013 ShowField=”NameWithPicture” can still be used. But in this case, user field will render correctly only if **<JSLink>clienttemplates.js</JSLink>** node is included in all Views. 

Looks like NameWithPicture value is no longer available via sharePoint GUI. It might mean that this value is depricated.
<img title="user broken.png" src="http://download-codeplex.sec.s-msft.com/Download?ProjectName=spcafcontrib&amp;DownloadId=778645" alt="user broken.png" />

### Resolution
Either **<JSLink>clienttemplates.js</JSLink>** has to be present in all views or **ShowField="NameWithPictureAndDetails"** has to be used instead of ShowField=”NameWithPicture”.

### Links
- [Field Element](http://msdn.microsoft.com/en-us/library/office/aa979575(v=office.14).aspx)
- [ShowField="NameWithPicture attribute breaks field rendering in SharePoint 2013](http://shareden.blogspot.ru/2013/11/showfieldnamewithpicture-attribute.html)