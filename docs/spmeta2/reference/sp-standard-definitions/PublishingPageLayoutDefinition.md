---
id: "publishingpagelayoutdefinition"
title: "PublishingPageLayoutDefinition"
scenario_model: "Web model"
scenario_category: "Master Page Gallery"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
List

## Notes
Publishing page layout provision is enabled via PublishingPageLayoutDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if a publishing page layout exists looking up it by FileName property, then creates a new one. You can deploy either single object or a set of the object using AddPublishingPageLayout() extension method as per following examples.

We suggest to use BuiltInListDefinitions.Calalogs.MasterPage to resolve built-in master page gallery list.

## Examples

### Add publishing page layout

```cs
var publishingPageContentType = new ContentTypeDefinition
{
    Name = "SPMeta2 Article",
    Id = new Guid("664CFB31-AFF3-433E-9F3F-D8812199B0BC"),
    Group = "SPMeta2.Samples",
    ParentContentTypeId = BuiltInPublishingContentTypeId.ArticlePage
};
 
var publshingPageLayout = new PublishingPageLayoutDefinition
{
    Title = "SPMeta2 Article Left Layout",
    FileName = "m2-article-left.aspx",
    // replace with your publishing page layout content
    Content = DefaultPublishingPageLayoutTemplates.ArticleLeft,
    AssociatedContentTypeId = publishingPageContentType.GetContentTypeId(),
    NeedOverride = true
};
 
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site.AddContentType(publishingPageContentType);
});
 
var rootWebModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
    {
        list.AddPublishingPageLayout(publshingPageLayout);
    });
});
 
DeployModel(siteModel);
DeployModel(rootWebModel);
```