---
id: "uniquecontenttypeorderdefinition"
title: "UniqueContentTypeOrderDefinition"
scenario_model: "Web model"
scenario_category: "Content Types"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Fields re-ordering inside a content type is enabled via UniqueContentTypeOrderDefinition object.

Both CSOM/SSOM object models are supported. Provision re-orders field links inside the content type according the ContentTypes property. You can deploy either single object or a set of the objects using AddUniqueContentTypeOrder() extension method as per following examples.
## Examples

### Reorder content types

```cs
var creditContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Credit",
    Id = new Guid("5D8346E4-A7AB-40AE-9AE9-22CF18170029"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var debitContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Debit",
    Id = new Guid("0C8D0474-384B-4765-8F84-993124447516"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var totalContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Total",
    Id = new Guid("110E6911-4611-4905-9E2F-46FEA608B418"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var annualRevenueList = new ListDefinition
{
    Title = "SPMeta2 Annual Revenue",
    Description = "A generic list.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    ContentTypesEnabled = true,
    Url = "M2AnnualRevenue"
};
 
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddContentType(creditContentType)
        .AddContentType(debitContentType)
        .AddContentType(totalContentType);
});
 
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(annualRevenueList, list =>
    {
        list
            .AddContentTypeLink(totalContentType)
            .AddContentTypeLink(creditContentType)
            .AddContentTypeLink(debitContentType)
            .AddUniqueContentTypeOrder(new UniqueContentTypeOrderDefinition
            {
                ContentTypes = new List<ContentTypeLinkValue>
                {
                    new ContentTypeLinkValue{ ContentTypeName = creditContentType.Name },
                    new ContentTypeLinkValue{ ContentTypeName = debitContentType.Name },
                    new ContentTypeLinkValue{ ContentTypeName = totalContentType.Name }
                }
            });
    });
});
 
DeployModel(siteModel);
DeployModel(webModel);
```