---
title: Incorrect 'Note' field index
id: resp515112
---
## Description
If you specify (thanks copy & paste) Indexed attribute for note field the follow exception will occuer during feature activation:

_Message: Microsoft.SharePoint.SPException: Cannot complete this action. Please try again.; System.Runtime.InteropServices.COMException: Cannot complete this action. Please try again.; StackTrace:    at Microsoft.SharePoint.Administration.SPElementDefinitionCollection.ProvisionListInstances(SPFeaturePropertyCollection props, SPSite site, SPWeb web, Boolean fForce)     at Microsoft.SharePoint.Administration.SPElementDefinitionCollection.ProvisionElements(SPFeaturePropertyCollection props, SPWebApplication webapp, SPSite site, SPWeb web, SPFeatureActivateFlags activateFlags, Boolean fForce)_

Maliciously formed XML:
```xml
<Field 
    group="My group"
    id="{FE2C05A9-1861-48C3-8DB4-3C08E9830E2C}" 
    type="Note" 
    displayname="Content" 
    description="Brief description." 
    required="TRUE" 
    indexed="TRUE" 
    numlines="6" 
    name="Name1"
    staticname="Name1" 
    overwrite="TRUE">
</Field>
```
Correctly forment XML, without Indexed attribute:
```xml
<Field 
    group="My group" 
    id="{FE2C05A9-1861-48C3-8DB4-3C08E9830E2C}" 
    type="Note" 
    displayname="Content"
    description="Brief description." 
    required="TRUE" 
    numlines="6" 
    name="Name1" 
    staticname="Name1" 
    overwrite="TRUE">
</Field>
```

## Resolution
Remove "Indexed" attribute from Field tag.

## Links
- [Field Element](http://msdn.microsoft.com/en-us/library/office/aa979575.aspx)
