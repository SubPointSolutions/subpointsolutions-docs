---
id: "resetroleinheritancedefinition"
title: "ResetRoleInheritanceDefinition"
scenario_model: "Web model"
scenario_category: "Security"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Resetting role inheritance operations over securable SharePoint objects are implemented with ResetRoleInheritanceDefinition.

ResetRoleInheritanceDefinition maps out SPSecurableObject.ResetRoleInheritance() method call.

Note that .AddResetRoleInheritance() syntax passes the object on which the method was called. For instance, for list, you would get the list wihtin AddResetRoleInheritance() as following: list.AddResetRoleInheritance(list => {} )

For web, you would get the web wihtin AddResetRoleInheritance() as following: web.AddResetRoleInheritance(web => {} )

## Examples

### Reset role inheritance on list

```cs
var listDef = new ListDefinition
{
    Title = "Public records",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    CustomUrl = "lists/public-records",
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(listDef, list =>
    {
        list.AddResetRoleInheritance(new ResetRoleInheritanceDefinition(), resetList =>
        {
            // resetList is your list but after resetting role inheritance
            // build your model as usual
 
            // resetList.AddListView(...)
        });
    });
});
 
DeployModel(model);

```

### Reset role inheritance on web

```cs
var publicProjectWebDef = new WebDefinition
{
    Title = "Public project",
    Url = "public-project",
    WebTemplate = BuiltInWebTemplates.Collaboration.TeamSite
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddWeb(publicProjectWebDef, publicProjectWeb =>
    {
        publicProjectWeb.AddResetRoleInheritance(new ResetRoleInheritanceDefinition(), publicProjectResetWeb =>
        {
            // publicProjectResetWeb is your web but after resetting role inheritance
            // build your model as usual
 
            // publicProjectResetWeb.AddList(...)
        });
    });
});
 
DeployModel(model);
```