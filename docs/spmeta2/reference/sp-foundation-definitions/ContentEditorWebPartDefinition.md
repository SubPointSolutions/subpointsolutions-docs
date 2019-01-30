---
id: "contenteditorwebpartdefinition"
title: "ContentEditorWebPartDefinition"
scenario_model: "Site collection model"
scenario_category: "Web Parts"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
WikiPage, WebPartPath, PublishingPage

## Notes
Content Editor Web Part provision is enabled via ContentEditorWebPartDefinition object.

There are two properties which are exposed by ContentEditorWebPartDefinition:

ContentLink, URL of a target content
Content, actual content
SPMeta2 adds the following tokens support for ContentLink property:

~sitecollection, replaced by site.ServerRelativeUrl
~site, replaced by web.ServerRelativeUrl
Both CSOM/SSOM object models are supported. You can deploy either single object or a set of the objects using AddContentEditorWebPart() extension method as per following examples.

## Examples

### Add CEWP

```cs
var cewp = new ContentEditorWebPartDefinition
{
    Title = "Empty Content Editor Webpart",
    Id = "m2EmptyCEWP",
    ZoneIndex = 10,
    ZoneId = "Main"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 CEWP provision",
    FileName = "cewp-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list.AddWebPartPage(webPartPage, page =>
        {
            page.AddContentEditorWebPart(cewp);
        });
    });
});
 
DeployModel(model);

```

### Add CEWP with link


```cs
var htmlContent = new ModuleFileDefinition
{
    FileName = "m2-cewp-content.html",
    Content = Encoding.UTF8.GetBytes("SPMeta2 is everything you need to deploy stuff to Sharepoint"),
    Overwrite = true,
};
 
var cewp = new ContentEditorWebPartDefinition
{
    Title = "Content Editor Webpart with URL link",
    Id = "m2ContentLinkCEWP",
    ZoneIndex = 20,
    ZoneId = "Main",
    ContentLink = UrlUtility.CombineUrl(new string[]{
            "~sitecollection",
            BuiltInListDefinitions.StyleLibrary.GetListUrl(),
            htmlContent.FileName})
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 CEWP provision",
    FileName = "cewp-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
        {
            list.AddModuleFile(htmlContent);
        })
        .AddHostList(BuiltInListDefinitions.SitePages, list =>
        {
            list.AddWebPartPage(webPartPage, page =>
            {
                page.AddContentEditorWebPart(cewp);
            });
        });
});
 
DeployModel(model);

```

### Add CEWP with content

```cs
var cewp = new ContentEditorWebPartDefinition
{
    Title = "Content Editor Webpart with content",
    Id = "m2ContentCEWP",
    ZoneIndex = 30,
    ZoneId = "Main",
    Content = "Content Editor web part inplace content."
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 CEWP provision",
    FileName = "cewp-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list.AddWebPartPage(webPartPage, page =>
        {
            page.AddContentEditorWebPart(cewp);
        });
    });
});
 
DeployModel(model);
```