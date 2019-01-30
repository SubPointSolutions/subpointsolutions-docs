---
id: "contentdatabasedefinition"
title: "ContentDatabaseDefinition"
scenario_model: "Web application model"
scenario_category: "Web Application"
---

## API support
[+] SSOM [-] CSOM

## Can be deployed under
WebApplication

## Notes
Content database provision is enabled via ContentDatabaseDefinition object.

## Examples

### Add alternate URL

```cs
var contentDb1 = new ContentDatabaseDefinition
{
    ServerName = "localhost",
    DbName = "intranet_content_db1"
};
 
var contentDb2 = new ContentDatabaseDefinition
{
    ServerName = "localhost",
    DbName = "intranet_content_db2"
};
 
var model = SPMeta2Model.NewWebApplicationModel(webApp =>
{
    webApp
        .AddContentDatabase(contentDb1)
        .AddContentDatabase(contentDb2);
});
 
DeployModel(model);
```