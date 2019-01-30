---
id: "wikipagedefinition"
title: "WikiPageDefinition"
scenario_model: "Web model"
scenario_category: "Wiki Pages"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Wiki page provision is enabled via WikiPageDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if wiki page exists looking up it by FileName property, then creates a new wiki page. You can deploy either single wiki page or a set of the pages using AddWikiPage() extension method as per following examples.

Content property gets copied to the wiki page via “SPBuiltInFieldId.WikiField” value.

Nesting under folders is supported as well.

## Examples

### Add wiki pages

```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list
            .AddWikiPage(DocWikiPages.AboutUs)
            .AddWikiPage(DocWikiPages.Contacts);
    });
});
 
DeployModel(model);

```

### Add wiki pages to folders
```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list
            .AddFolder(DocFolders.WikiPages.News, newsFolder =>
            {
                newsFolder
                    .AddWikiPage(DocWikiPages.NewCoffeeMachine)
                    .AddWikiPage(DocWikiPages.NewSPMeta2Release);
            })
            .AddFolder(DocFolders.WikiPages.Archive, archiveFolder =>
            {
                archiveFolder
                   .AddWikiPage(DocWikiPages.December2012News)
                   .AddWikiPage(DocWikiPages.October2012News);
            });
    });
});
 
DeployModel(model);
```