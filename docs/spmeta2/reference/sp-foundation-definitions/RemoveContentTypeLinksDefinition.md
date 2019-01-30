---
id: "removecontenttypelinksdefinition"
title: "RemoveContentTypeLinksDefinition"
scenario_model: "Web model"
scenario_category: "Content Types"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Removing content types inside a list is enabled via RemoveContentTypeLinksDefinition object.

Both CSOM/SSOM object models are supported. Provision removed content type links inside the list according the ContentTypes property. You can deploy either single object or a set of the objects using AddRemoveContentTypeLinks() extension method as per following examples.

## Examples

### Remove content types from lists

```cs
var defaultReport = new ContentTypeDefinition
{
    Name = "SPMeta2 Default Report",
    Id = new Guid("E2134FA1-254A-41AF-8BB0-A0A521722832"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var defaultReportsList = new ListDefinition
{
    Title = "SPMeta2 Default Reports",
    Description = "A generic list.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    ContentTypesEnabled = true,
    Url = "M2DefaultReports"
};
 
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddContentType(defaultReport);
});
 
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(defaultReportsList, list =>
    {
        list
            .AddContentTypeLink(defaultReport)
            .AddRemoveContentTypeLinks(new RemoveContentTypeLinksDefinition
            {
                ContentTypes = new List<ContentTypeLinkValue>
                {
                    new ContentTypeLinkValue{ ContentTypeName = "Item"}
                }
            });
    });
});
 
DeployModel(siteModel);
DeployModel(webModel);
```
