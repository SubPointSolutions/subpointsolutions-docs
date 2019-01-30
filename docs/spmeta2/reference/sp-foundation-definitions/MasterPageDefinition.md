---
id: "masterpagedefinition"
title: "MasterPageDefinition"
scenario_model: "Web model"
scenario_category: "Master Page Gallery"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Master page provision is enabled via MasterPageDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if a master page exists looking up it by FileName property, then creates a new one. You can deploy either single object or a set of the object using AddMasterPage() extension method as per following examples.

We suggest to use BuiltInListDefinitions.Calalogs.MasterPage to resolve built-in master page gallery list.

## Examples

### Add master page

```cs
var masterPage = new MasterPageDefinition
{
    Title = "SPMeta2 Oslo",
    FileName = "m2-oslo.master",
    // replace with your master page content
    Content = Encoding.UTF8.GetBytes(DefaultMasterPageTemplates.Oslo),
    NeedOverride = true
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
    {
        list.AddMasterPage(masterPage);
    });
});
 
DeployModel(model);
```