---
id: "listfieldlinkdefinition"
title: "ListFieldLinkDefinition"
scenario_model: "Web model"
scenario_category: "Lists and Libraries"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Adding site/web field to the list is enabled via AddListFieldLinkDefinition object.

Provision checks if field exists in the list adding a new one as per ListFieldLinkDefinition object.
## Examples

### Add field links to list

```cs
var fieldDef = new TextFieldDefinition
{
    Title = "Customer number",
    InternalName = "m2CustomNumber",
    Id = new Guid("87247c7d-1ecc-4503-bfd5-21f107b442fb")
};
 
var listDef = new ListDefinition
{
    Title = "Customers",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    CustomUrl = "lists/customers",
};
 
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site.AddTextField(fieldDef);
});
 
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(listDef, list =>
    {
        // will add a link to the site level field
        list.AddListFieldLink(fieldDef);
    });
});
 
DeployModel(siteModel);
DeployModel(webModel);
```