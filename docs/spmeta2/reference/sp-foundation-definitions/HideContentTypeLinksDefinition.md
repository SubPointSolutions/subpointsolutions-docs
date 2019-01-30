---
id: "hidecontenttypelinksdefinition"
title: "HideContentTypeLinksDefinition"
scenario_model: "Web model"
scenario_category: "Content Types"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Hiding content types inside a list is enabled via HideContentTypeLinksDefinition object.

Both CSOM/SSOM object models are supported. Provision makes fields non-required and hide them inside the content type according the Fields property. You can deploy either single object or a set of the objects using AddHideContentTypeLinks() extension method as per following examples.

## Examples

### Reorder content type fields

```cs
var newAnnualReportContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Annual Report 2015",
    Id = new Guid("7B3378FF-11DF-430B-830F-C63FABA4712F"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var oldAnnualReportContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Annual Report 2014",
    Id = new Guid("DEB586C5-ED08-4D06-98F6-9FC5002986D2"),
    ParentContentTypeId = BuiltInContentTypeId.Item,
    Group = "SPMeta2.Samples"
};
 
var annualReportsList = new ListDefinition
{
    Title = "SPMeta2 Annual Reports",
    Description = "A generic list.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    ContentTypesEnabled = true,
    Url = "M2AnnualReports"
};
 
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddContentType(newAnnualReportContentType)
        .AddContentType(oldAnnualReportContentType);
});
 
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(annualReportsList, list =>
    {
        list
            .AddContentTypeLink(newAnnualReportContentType)
            .AddContentTypeLink(oldAnnualReportContentType)
            .AddHideContentTypeLinks(new HideContentTypeLinksDefinition
            {
                ContentTypes = new List<ContentTypeLinkValue>
                {
                    new ContentTypeLinkValue{ ContentTypeName = "Item" },
                    new ContentTypeLinkValue{ ContentTypeName = oldAnnualReportContentType.Name }
                }
            });
    });
});
 
DeployModel(siteModel);
DeployModel(webModel);
```