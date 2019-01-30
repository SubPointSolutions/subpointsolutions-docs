---
id: "deletewebpartsdefinition"
title: "DeleteWebPartsDefinition"
scenario_model: "Site collection model"
scenario_category: "Web Part Pages"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
WikiPage, WebPartPage, PublishingPage

## Notes
Web parts deletion is suppoerted by DeleteWebPartsDefinition.

DeleteWebPartsDefinition can be added to any page: wiki, publishing or web part page. Use .AddDeleteWebParts() with new DeleteWebPartsDefinition.

DeleteWebPartsDefinition has .WebParts property that stores 'web part matches' to find web part for deletion operation. WebPartMatch has three properties - Title, Id and WebpartType to lookup the targer web part.

Note that only WebPartMatch.Title is currently used to find the web part on the pages. Id and WebpartType are reserverd for the future API enhancements.

## Examples

### Delete web part by Title

```cs
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 webparts",
    FileName = "web-parts.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
// aiming to delete two web part with the following titles:
// 'My Tasks'
// 'My Projects'
var myWebPartDeletionDef = new DeleteWebPartsDefinition
{
    WebParts = new List<WebPartMatch>(new WebPartMatch[] {
        new WebPartMatch {
            Title = "My Tasks"
        },
        new WebPartMatch {
            Title = "My Projects"
        }
    })
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list.AddWebPartPage(webPartPage, page =>
        {
            page.AddDeleteWebParts(myWebPartDeletionDef);
        });
    });
});
 
DeployModel(model);

```