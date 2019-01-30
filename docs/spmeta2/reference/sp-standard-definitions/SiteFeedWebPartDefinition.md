---
id: "sitefeedwebpartdefinition"
title: "SiteFeedWebPartDefinition "
scenario_model: "Web model"
scenario_category: "Web Parts"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
List

## Notes
SiteFeedWebPart provision is enabled via SiteFeedWebPartDefinition object.

Both CSOM/SSOM object models are supported. You can deploy either single object or a set of the objects using AddSiteFeedWebPart() extension method as per following examples

## Examples

### Add Site Feed web part

```cs
var siteFeed = new SiteFeedWebPartDefinition
{
    Title = "Site Feed",
    Id = "m2SiteFeed",
    ZoneIndex = 10,
    ZoneId = "Main"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 Site Feed provision",
    FileName = "site-feed-webpart-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddWebFeature(BuiltInWebFeatures.SiteFeed.Inherit().Enable())
      .AddHostList(BuiltInListDefinitions.SitePages, list =>
      {
          list.AddWebPartPage(webPartPage, page =>
          {
              page.AddSiteFeedWebPart(siteFeed);
          });
      });
});
 
DeployModel(model);
```