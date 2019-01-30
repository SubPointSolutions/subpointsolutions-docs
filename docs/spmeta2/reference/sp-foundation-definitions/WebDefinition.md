---
id: "webdefinition"
title: "WebDefinition"
scenario_model: "Web model"
scenario_category: "Site Collection"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
User custom action provision is enabled via UserCustomActionDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if object exists looking up it by Name property, then creates a new object. You can deploy either single object or a set of the objects using AddUserCustomAction() extension method as per following examples.

## Examples

### Add web
```cs
var newCustomerWeb = new WebDefinition
{
    Title = "New customer site",
    Description = "A dedicated site for the customer support.",
    Url = "new-customer-web",
    WebTemplate = BuiltInWebTemplates.Collaboration.TeamSite
};
var newPublishingWeb = new WebDefinition
{
    Title = "Temporary Publishing Web",
    Description = "A temporary punlishing web.",
    Url = "new-publishing-web",
    WebTemplate = BuiltInWebTemplates.Publishing.PublishingPortal
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddWeb(newCustomerWeb);
    web.AddWeb(newPublishingWeb);
});
 
DeployModel(model);

```

### Add multiple webs

```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddWeb(DocWebs.News);
    web.AddWeb(DocWebs.AboutOurCompany);
});
 
DeployModel(model);

```

### Add hierarchical webs

```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddWeb(DocWebs.News)
        .AddWeb(DocWebs.Departments, departmentWeb =>
        {
            departmentWeb
                .AddWeb(DocWebs.DepartmentWebs.HR)
                .AddWeb(DocWebs.DepartmentWebs.ITHelpDesk, itWeb =>
                {
                    itWeb
                        .AddWeb(DocWebs.DepartmentWebs.ITHelpDeskWebs.Apple)
                        .AddWeb(DocWebs.DepartmentWebs.ITHelpDeskWebs.Cisco)
                        .AddWeb(DocWebs.DepartmentWebs.ITHelpDeskWebs.Microsoft);
                })
                .AddWeb(DocWebs.DepartmentWebs.Sales);
        })
        .AddWeb(DocWebs.AboutOurCompany);
});
 
DeployModel(model);
```