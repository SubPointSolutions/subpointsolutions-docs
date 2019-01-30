---
id: "appdefinition"
title: "AppDefinition"
scenario_model: "Web model"
scenario_category: "Web"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Web

## Notes
Apps provision is enabled via AppDefinition object.

Provision checks if app exists, deploying a new app or upgrading using Version property.

## Examples

### Add app

```cs
var appDef = new AppDefinition
{
    Content = File.ReadAllBytes("path-to-your-app-file"),
    ProductId = new Guid("your-app-product-id"),
    // your app version
    Version = "1.0.0.0"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddApp(appDef);
});
 
DeployModel(model);
```