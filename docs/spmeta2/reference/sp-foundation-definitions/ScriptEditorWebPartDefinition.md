---
id: "scripteditorwebpartdefinition"
title: "ScriptEditorWebPartDefinition"
scenario_model: "Web model"
scenario_category: "Web Parts"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes

ScriptEditorWebPart provision is enabled via ScriptEditorWebPartDefinition object.

Both CSOM/SSOM object models are supported. You can deploy either single object or a set of the objects using AddScriptEditorWebPart() extension method as per following examples

Be aware that ID property must be more than 32 chars, that's a SharePoint API issues.

## Examples

### Add Script Editor web part

```cs
var scriptEditor = new ScriptEditorWebPartDefinition
{
    Title = "Empty Script Editor",
    Id = "m2EmptyScriptEditorrWhichMustBeMoreThan32Chars",
    ZoneIndex = 10,
    ZoneId = "Main"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 Script Editor provision",
    FileName = "script-editor-webpart-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddHostList(BuiltInListDefinitions.SitePages, list =>
      {
          list.AddWebPartPage(webPartPage, page =>
          {
              page.AddScriptEditorWebPart(scriptEditor);
          });
      });
});
 
DeployModel(model);

```

### Add Script Editor web part with content

```cs
var scriptEditor = new ScriptEditorWebPartDefinition
{
    Title = "Pre-provisioned Script Editor",
    Id = "m2ScriptEditorWithLoggerWhichMustBeMoreThan32Chars",
    ZoneIndex = 20,
    ZoneId = "Main",
    Content = " <script> console.log('script editor log');  </script> Pre-provisioned Script Editor Content"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 Script Editor provision",
    FileName = "script-editor-webpart-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddHostList(BuiltInListDefinitions.SitePages, list =>
      {
          list.AddWebPartPage(webPartPage, page =>
          {
              page.AddScriptEditorWebPart(scriptEditor);
          });
      });
});
 
DeployModel(model);
```