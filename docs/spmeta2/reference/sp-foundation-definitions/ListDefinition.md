---
id: "listdefinition"
title: "ListDefinition"
scenario_model: "Web model"
scenario_category: "Lists and Libraries"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Hiding content types inside a list is enabled via HideContentTypeLinksDefinition object.

Both CSOM/SSOM object models are supported. Provision makes fields non-required and hide them inside the content type according the Fields property. You can deploy either single object or a set of the objects using AddHideContentTypeLinks() extension method as per following examples.

## Examples

### Add list by template type
```cs
var genericList = new ListDefinition
{
    Title = "Generic list",
    Description = "A generic list.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "GenericList"
};
 
var documentLibrary = new ListDefinition
{
    Title = "Document library",
    Description = "A document library.",
    TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
    Url = "DocumentLibrary"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(genericList);
    web.AddList(documentLibrary);
});
 
DeployModel(model);

```

### Add list by template name

```cs
var contactsList = new ListDefinition
{
    Title = "Some Assert",
    Description = "Some Assert.",
    TemplateName = BuiltInListTemplates.AssetLibrary.InternalName,
    Url = "SomeAssert"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(contactsList);
});
 
DeployModel(model);


```

### Add host Style Library
```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
    {
        // do stuff
    });
});
 
DeployModel(model);

```

### Add host OOTB lists
```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
    {
        // do stuff
    });
 
    web.AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
    {
        // do stuff
    });
 
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        // do stuff
    });
 
    web.AddHostList(BuiltInListDefinitions.SiteAssets, list =>
    {
        // do stuff
    });
});
 
DeployModel(model);

```

### Add multiple lists


```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddWeb(DocWebs.AboutOurCompany, aboutWeb =>
        {
            aboutWeb
                .AddList(DocLists.AboutUsLists.ManagementTeam)
                .AddList(DocLists.AboutUsLists.OurClients);
        })
        .AddWeb(DocWebs.DepartmentWebs.HR, hrWeb =>
        {
            hrWeb
                .AddList(DocLists.HRLists.AnnualReviews)
                .AddList(DocLists.HRLists.Poicies)
                .AddList(DocLists.HRLists.Procedures);
        })
        .AddWeb(DocWebs.Departments, departmentWeb =>
        {
            departmentWeb
                .AddList(DocLists.DepartmentsLists.IssueRegister)
                .AddList(DocLists.DepartmentsLists.TeamEvents)
                .AddList(DocLists.DepartmentsLists.TeamTasks);
        });
});
 
DeployModel(model);

```

### Add promoted links list

```cs
var listDef = new ListDefinition
{
    Title = "My Links",
    TemplateName = BuiltInListTemplates.PromotedLinks.InternalName,
    CustomUrl = "/lists/my-links"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(listDef);
});
 
DeployModel(model);
```