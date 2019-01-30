---
id: "alternateurldefinition"
title: "AlternateUrlDefinition"
scenario_model: "Web application model"
scenario_category: "Web application"
---

## API support
[+] SSOM [-] CSOM

## Can be deployed under
WebApplication

## Notes
AAM provision is enabled via AlternateUrlDefinition object.
Provision checks if AAM exists, deploying a new one using URL as a key.

## Examples


### Add alternate URL

```cs
var internalDef = new AlternateUrlDefinition
{
    Url = "http://the-portal",
    UrlZone = BuiltInUrlZone.Intranet
};
 
var intranetDef = new AlternateUrlDefinition
{
    Url = "http://my-intranet.com.au",
    UrlZone = BuiltInUrlZone.Internet
};
 
var model = SPMeta2Model.NewWebApplicationModel(webApp =>
{
    webApp.AddAlternateUrl(internalDef);
    webApp.AddAlternateUrl(intranetDef);
});
 
DeployModel(model);
```