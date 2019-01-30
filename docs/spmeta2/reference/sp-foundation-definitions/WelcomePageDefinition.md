---
id: "welcomepagedefinition"
title: "WelcomePageDefinition"
scenario_model: "Web model"
scenario_category: "Welcome Page"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Welcome page provision is enabled via WelcomePageDefinition object.

Both CSOM/SSOM object models are supported. Using the only property Url, provision updates WelcomePage property for a target artifact - web, list or folder. Url should be object-related, a web related for the web, a list related and folder related for list and web accordingly.

## Examples

### Add web welcome page

```cs
var newWebHomePage = new WikiPageDefinition
{
    FileName = "A new landing page for web.aspx",
    Content = "Hello, this is a new web landing page!"
};
 
var welcomePage = new WelcomePageDefinition
{
    // should be relating to the web!
    Url = UrlUtility.CombineUrl(BuiltInListDefinitions.SitePages.GetListUrl(), newWebHomePage.FileName)
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddHostList(BuiltInListDefinitions.SitePages, list =>
        {
            list.AddWikiPage(newWebHomePage);
        })
        .AddWelcomePage(welcomePage);
});
 
DeployModel(model);

```

### Add list welcome page

```cs
var newListHomePage = new WikiPageDefinition
{
    FileName = "A new landing page for list.aspx",
    Content = "Hello, this is a new list landing page!"
};
 
var welcomePage = new WelcomePageDefinition
{
    // should be relating to the list!
    Url = newListHomePage.FileName
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddHostList(BuiltInListDefinitions.SitePages, list =>
        {
            list
                .AddWikiPage(newListHomePage)
                .AddWelcomePage(welcomePage);
        });
});
 
DeployModel(model);

```

### Add folder welcome page

```cs
var newFolderHomePage = new WikiPageDefinition
{
    FileName = "A new landing page for folder.aspx",
    Content = "Hello, this is a new folder landing page!"
};
 
var welcomePage = new WelcomePageDefinition
{
    // should be relating to the folder!
    Url = newFolderHomePage.FileName
};
 
var landingPageFolder = new FolderDefinition
{
    Name = "A folder with custom landing page"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddHostList(BuiltInListDefinitions.SitePages, list =>
        {
            list
                .AddFolder(landingPageFolder, folder =>
                {
                    folder
                        .AddWikiPage(newFolderHomePage)
                        .AddWelcomePage(welcomePage);
                });
        });
});
 
DeployModel(model);
```