---
id: "rootwebdefinition"
title: "RootWebDefinition"
scenario_model: "Web model"
scenario_category: "Root Web"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Root web provision is enabled via RootWebDefinition object.

There are two cases for which RootWebDefinition could be of use:

We need to rename Title/Description of the root web
We need to 'lookup' the root web to provision content on root web
If Title/Description are not provided, provision does not change anything.

Both CSOM/SSOM object models are supported.

## Examples

### Update root web Title/Description

```cs
var rootWeb = new RootWebDefinition
{
    Title = "SPMeta2 CRM",
    Description = "Custom CRM application build on top of SPMeta2 framework."
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddRootWeb(rootWeb);
});
 
DeployModel(model);
```

### Add lists to root web

```cs
var rootWeb = new RootWebDefinition
{
 
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddRootWeb(rootWeb, web =>
    {
        web
          .AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
          {
              // do stuff with 'Style Library'
          })
          .AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
          {
              // do stuff with 'Master Page Library'
          });
    });
});
 
DeployModel(model);
```