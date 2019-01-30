---
id: "webpartpagedefinition"
title: "WebPartPageDefinition"
scenario_model: "Web model"
scenario_category: "Web Part Pages"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes

Web part page provision via WebPartPageDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if artifact exists looking up it by FileName property, then creates a new site field. You can deploy either single page or a set of the pages using AddWebPartPage() extension method as per following examples.

We suggest to use BuiltInWebPartPageTemplates to address PageLayoutTemplate property. Use CustomPageLayout in case you need a custom web part page template.

## Examples

### Add web part page

```cs
var customersReportPage = new WebPartPageDefinition
{
    Title = "Customer reports",
    FileName = "Customers-report.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var parthesReportPage = new WebPartPageDefinition
{
    Title = "Parthers reports",
    FileName = "Parthers-report.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd2
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list
            .AddWebPartPage(customersReportPage)
            .AddWebPartPage(parthesReportPage);
    });
});
 
DeployModel(model);
```

### Add custom web part page

```cs
var customizedWebPartPage = new WebPartPageDefinition
{
    Title = "Customers report",
    FileName = "Customers-report.aspx",
    CustomPageLayout = "___ a custom web part page template here ___ "
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list
            .AddWebPartPage(customizedWebPartPage);
    });
});
 
DeployModel(model);

```

### Add web part page to folder

```cs
// clients folder and pages
var clientsFolder = new FolderDefinition()
{
    Name = "Customers"
};
 
var clientMay2015Page = new WebPartPageDefinition
{
    Title = "May 2015",
    FileName = "May-2015-analytics.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var clientJune2015Page = new WebPartPageDefinition
{
    Title = "June 2015",
    FileName = "June-2015-analytics.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
// parthers folder and pages
var parthersFolder = new FolderDefinition()
{
    Name = "Parthers"
};
 
var parther2014AnnualReport = new WebPartPageDefinition
{
    Title = "Annual report 2014",
    FileName = "Annual-report-2014.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var parther2015AnnualReport = new WebPartPageDefinition
{
    Title = "Annual report 2015",
    FileName = "Annual-report-2015.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1,
};
 
// linking everything together
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list
            .AddFolder(clientsFolder, folder =>
            {
                folder
                    .AddWebPartPage(clientMay2015Page)
                    .AddWebPartPage(clientJune2015Page);
            })
            .AddFolder(parthersFolder, folder =>
            {
                folder
                  .AddWebPartPage(parther2014AnnualReport)
                  .AddWebPartPage(parther2015AnnualReport);
            });
    });
});
 
DeployModel(model);
```