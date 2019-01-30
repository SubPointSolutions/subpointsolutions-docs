---
id: "prefixdefinition"
title: "PrefixDefinition"
scenario_model: "Web model"
scenario_category: "Web Application"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Prefix provision is enabled via PrefixDefinition object.

Provision checks if prefix exists, deploying a new one using Path as a key.

## Examples

### Add module file to Style Library
```cs
var prefixDef = new PrefixDefinition
{
    Path = "projects",
    PrefixType = BuiltInPrefixTypes.WildcardInclusion
};
 
var model = SPMeta2Model.NewWebApplicationModel(webApp =>
{
    webApp.AddPrefix(prefixDef);
});
 
DeployModel(model);
```