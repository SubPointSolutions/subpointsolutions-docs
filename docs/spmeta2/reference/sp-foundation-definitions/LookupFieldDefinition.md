---
id: "lookupfielddefinition"
title: "LookupFieldDefinition"
scenario_model: "Web model"
scenario_category: "Fields"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Lookup field provision is enabled via LookupFieldDefinition object.

Both CSOM/SSOM object models are supported. 
You can deploy either single object or a set of the objects using AddLookupField() extension method as per following examples.

The following properties allow to adjust the desired field configuration:

One of the following properties are used to bind the field to the target list.
If none of them are defined, then lookup field is left unbinded.

* **LookupList**, GUID of the target list. Could also be "Self" or "UserInfo"
* **LookupListTitle**, Title of the target list
* **LookupListUrl**, web relative URL of the target list

* **LookupWebId**, Id od the target web if list is located on non-root web
* **LookupField**, refers to 'ShowField' property

**Provisioning on existing lists** could be done setting up the following properties:

* One of LookupList, LookupListTitle or LookupListUrl
* LookupWebId, if the list exists on non-root web
* LookupField, if it is different to 'Title'

Provision would create a lookup field and bind it to the target list.

**Provisioning on lists which don't exist yet** could be done the following way:

* Define lookup field without setting up a target list, then provision the field. 
* Provision all the list which you need
* Setup one of LookupList, LookupListTitle or LookupListUrl. LookupField and LookupWebId if needed
* Proivision lookup field again

That provision flow would create a lookup field without binding to the list, then you creare needed lists, and then re-provision lookup field again - that would bind field to the list.

## Examples

### Add lookup field

```cs
var emptyLookupField = new LookupFieldDefinition
{
    Title = "Empty Lookup Field",
    InternalName = "m2EmptyLookupField",
    Group = "SPMeta2.Samples",
    Id = new Guid("B6387953-3967-4023-9D38-431F2C6A5E54")
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddField(emptyLookupField);
});
 
DeployModel(model);
```

### Add lookup field binded to list
```cs
var leadTypeLookup = new LookupFieldDefinition
{
    Title = "Lead Type",
    InternalName = "m2LeadType",
    Group = "SPMeta2.Samples",
    Id = new Guid("FEFC30A7-3B38-4034-BB2A-FFD538D46A63")
};
 
var lookupFieldModel = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddField(leadTypeLookup);
});
 
var leadRecords = new ListDefinition
{
    Title = "Lead Records",
    Description = "A generic list.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "m2LeadRecordsList"
};
 
var leadRecordTypes = new ListDefinition
{
    Title = "Lead Record Types",
    Description = "A generic list.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "m2LeadRecordTypesList"
};
 
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddList(leadRecords, list =>
      {
          list.AddListFieldLink(leadTypeLookup);
      })
      .AddList(leadRecordTypes);
});
 
// 1. deploy lookup field without bindings
DeployModel(lookupFieldModel);
 
// 2. deploy lists
DeployModel(webModel);
 
// 3. update binding for the lookup field
// LookupList/LookupListId could also be used
leadTypeLookup.LookupListTitle = leadRecordTypes.Title;
 
// 4. deploy lookup field again, so that it will be binded
DeployModel(lookupFieldModel);
```