---
id: "treeviewsettingsdefinition"
title: "TreeViewSettingsDefinition"
scenario_model: "Web model"
scenario_category: "Web"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Provision updates tree view and quick launch settings of the given web site.

Both CSOM/SSOM object models are supported. You can deploy either single object or a set of the objects using AddTreeViewSettings() extension method as per following examples.

## Examples

### Add tree view settings to web

```cs
var treeViewSettings = new TreeViewSettingsDefinition
{
    TreeViewEnabled = true,
    QuickLaunchEnabled = true
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddTreeViewSettings(treeViewSettings);
});
 
DeployModel(model);
```