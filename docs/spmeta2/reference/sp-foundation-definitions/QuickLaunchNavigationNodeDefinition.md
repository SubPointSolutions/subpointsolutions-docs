---
id: "quicklaunchnavigationnodedefinition"
title: "QuickLaunchNavigationNodeDefinition"
scenario_model: "Web model"
scenario_category: "Navigation"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Quick launch navigation is enabled via QuickLaunchNodeNavigation object.

Both CSOM/SSOM object models are supported. Provision checks if object exists looking up it by Url/Title property, then creates a new one. You can deploy either single node or a set of the nodes using AddQuickLaunchNavigationNode() extension method as per following examples.

## Examples

### Add quick nav items

```cs
var aboutUs = new QuickLaunchNavigationNodeDefinition
{
    Title = "About us",
    Url = "about-us.aspx",
    IsExternal = true
};
 
var services = new QuickLaunchNavigationNodeDefinition
{
    Title = "Services",
    Url = "services.aspx",
    IsExternal = true
};
 
var contacts = new QuickLaunchNavigationNodeDefinition
{
    Title = "Contacts",
    Url = "contacts.aspx",
    IsExternal = true
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddQuickLaunchNavigationNode(aboutUs)
        .AddQuickLaunchNavigationNode(services)
        .AddQuickLaunchNavigationNode(contacts);
});
 
DeployModel(model);
```

### Add hierarchical quick nav items

```cs
// top level departments node
var departments = new QuickLaunchNavigationNodeDefinition
{
    Title = "Departments",
    Url = "departments.aspx",
    IsExternal = true
};
 
var hr = new QuickLaunchNavigationNodeDefinition
{
    Title = "HR",
    Url = "hr.aspx",
    IsExternal = true
};
 
var it = new QuickLaunchNavigationNodeDefinition
{
    Title = "IT",
    Url = "it.aspx",
    IsExternal = true
};
 
// top level clients node
var clients = new QuickLaunchNavigationNodeDefinition
{
    Title = "Clients",
    Url = "clients.aspx",
    IsExternal = true
};
 
var microsoft = new QuickLaunchNavigationNodeDefinition
{
    Title = "Microsoft",
    Url = "microsfot.aspx",
    IsExternal = true
};
 
var apple = new QuickLaunchNavigationNodeDefinition
{
    Title = "Apple",
    Url = "apple.aspx",
    IsExternal = true
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddQuickLaunchNavigationNode(departments, node =>
        {
            node
                .AddQuickLaunchNavigationNode(hr)
                .AddQuickLaunchNavigationNode(it);
        })
        .AddQuickLaunchNavigationNode(clients, node =>
        {
            node
              .AddQuickLaunchNavigationNode(microsoft)
              .AddQuickLaunchNavigationNode(apple);
        });
});
 
DeployModel(model);
```