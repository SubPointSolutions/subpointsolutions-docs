---
id: "usercustomactiondefinition"
title: "UserCustomActionDefinition"
scenario_model: "Web model"
scenario_category: "User Custom Action"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
User custom action provision is enabled via UserCustomActionDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if object exists looking up it by Name property, then creates a new object. You can deploy either single object or a set of the objects using AddUserCustomAction() extension method as per following examples.

## Examples

### Add custom action to site

```cs
var siteLogger = new UserCustomActionDefinition
{
    Name = "m2SiteLogger",
    Location = "ScriptLink",
    ScriptBlock = "console.log('site logger on site:' + _spPageContextInfo.siteAbsoluteUrl);",
    Sequence = 1000
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddUserCustomAction(siteLogger);
});
 
DeployModel(model);

```

### Add custom action with jQuery

```cs
var jQueryFile = new ModuleFileDefinition
{
    FileName = "jquery-1.11.2.min.js",
    Content = ModuleFileUtils.FromResource(GetType().Assembly, "SPMeta2.Docs.Modules.jquery-1.11.2.min.js"),
    Overwrite = true
};
 
var appScriptsFolder = new FolderDefinition
{
    Name = "SPMeta2 App Scripts"
};
 
var jQueryCustomAction = new UserCustomActionDefinition
{
    Name = "m2jQuery",
    Location = "ScriptLink",
    ScriptSrc = UrlUtility.CombineUrl(new string[]
    {
        "~sitecollection",
        BuiltInListDefinitions.StyleLibrary.GetListUrl(),
        appScriptsFolder.Name,
        jQueryFile.FileName
    }),
    Sequence = 1500
};
 
var jQuerySiteLogger = new UserCustomActionDefinition
{
    Name = "m2jQuerySiteLogger",
    Location = "ScriptLink",
    ScriptBlock = "jQuery(document).ready( function() { console.log('jQuery site logger on site:' + _spPageContextInfo.siteAbsoluteUrl); } );",
    Sequence = 1600
};
 
var siteModel = SPMeta2Model.NewSiteModel(site =>
{
    site
      .AddUserCustomAction(jQueryCustomAction)
      .AddUserCustomAction(jQuerySiteLogger);
});
 
var webModel = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
    {
        list.AddFolder(appScriptsFolder, folder =>
        {
            folder.AddModuleFile(jQueryFile);
        });
    });
});
 
DeployModel(siteModel);
DeployModel(webModel);

```

### Add custom action to web

```cs
var webLogger = new UserCustomActionDefinition
{
    Name = "m2WebLogger",
    Location = "ScriptLink",
    ScriptBlock = "console.log('site logger on web:' + _spPageContextInfo.webAbsoluteUrl);",
    Sequence = 1800
};
 
var loggerWeb = new WebDefinition
{
    Title = "SPMeta2 Logger Web",
    Url = "m2logging",
    WebTemplate = BuiltInWebTemplates.Collaboration.TeamSite
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddWeb(loggerWeb, subWeb =>
    {
        subWeb.AddUserCustomAction(webLogger);
    });
});
 
DeployModel(model);

```