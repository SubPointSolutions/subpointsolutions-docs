---
id: "farmdefinition"
title: "FarmDefinition"
scenario_model: "Farm model"
scenario_category: "Farm"
---

## API support
[+] SSOM [-] CSOM

## Can be deployed under
Farm

## Notes
FarmDefinition is used to craft the farm model within SPMeta2Model.NewFarmModel(farm) construction.

Available only in SSOM. Used to resolve the current farm and start provision under the farm object (features, web apps and other artifacts).

## Examples

### Add farm feature

```cs
var farmFeature = BuiltInFarmFeatures.SiteMailboxes.Inherit(f =>
{
    f.Enable = true;
});
 
var model = SPMeta2Model.NewFarmModel(farm =>
{
    farm.AddFarmFeature(farmFeature);
});
 
DeployModel(model);
```