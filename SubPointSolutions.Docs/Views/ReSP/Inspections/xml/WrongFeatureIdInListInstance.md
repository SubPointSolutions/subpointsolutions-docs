---
Title: Wrong FeatureId for list instance
FileName: resp515405
---
### Description
When creating a list instance manually in a SharePont, it is important to remember to add the right FeatureId attribute to the ListInstance element, if the TemplateType attribute points to a list template which is not in the same feature as the one you are creating the list instance in. If you forget, you will get some very vague error messages.

*Error occurred in deployment step 'Activate Features': Invalid file name.
The file name you specified could not be used. It may be the name of an existing file or directory, or you may not have permission to access the file.*

If left out, SharePoint assumes that the list template exists in the same feature as the list instance.

### Resolution
Check FeatureId attribute value that it should point to the valid feature.

### Links
- [ListInstance Element](https://msdn.microsoft.com/en-us/library/office/ms476062.aspx)
- [Setting the right value of the FeatureId attribute for ListInstance](http://blog.mastykarz.nl/setting-featureid-attribute-listinstance/)
