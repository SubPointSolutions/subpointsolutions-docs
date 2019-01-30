---
id: "topnavigationnodedefinition"
title: "TopNavigationNodeDefinition"
scenario_model: "Web model"
scenario_category: "Navigation"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Top navigation is enabled via TopNavigationNodeDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if object exists looking up it by Url/Title property, then creates a new one. You can deploy either single mode or a set of the nodes using AddTopNavigationNode() extension method as per following examples.
## Examples

### Add top nav items

```cs
var ourCompany = new TopNavigationNodeDefinition
{
    Title = "Our Company",
    Url = "our-company.aspx",
    IsExternal = true
};
 
var ourServices = new TopNavigationNodeDefinition
{
    Title = "Our Services",
    Url = "our-services.aspx",
    IsExternal = true
};
 
var ourTeam = new TopNavigationNodeDefinition
{
    Title = "Our Team",
    Url = "our-team.aspx",
    IsExternal = true
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddTopNavigationNode(ourCompany)
        .AddTopNavigationNode(ourServices)
        .AddTopNavigationNode(ourTeam);
});
 
DeployModel(model);

```

### Add hierarchical top nav items

```cs
// top level departments node
var departments = new TopNavigationNodeDefinition
{
    Title = "Our Departments",
    Url = "our-departments.aspx",
    IsExternal = true
};
 
var hr = new TopNavigationNodeDefinition
{
    Title = "HR Team",
    Url = "hr-team.aspx",
    IsExternal = true
};
 
var it = new TopNavigationNodeDefinition
{
    Title = "IT Team",
    Url = "it-team.aspx",
    IsExternal = true
};
 
// top level clients node
var partners = new TopNavigationNodeDefinition
{
    Title = "Our Partners",
    Url = "our-partners.aspx",
    IsExternal = true
};
 
var microsoft = new TopNavigationNodeDefinition
{
    Title = "Microsoft",
    Url = "microsfot.aspx",
    IsExternal = true
};
 
var apple = new TopNavigationNodeDefinition
{
    Title = "Apple",
    Url = "apple.aspx",
    IsExternal = true
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
        .AddTopNavigationNode(departments, node =>
        {
            node
                .AddTopNavigationNode(hr)
                .AddTopNavigationNode(it);
        })
        .AddTopNavigationNode(partners, node =>
        {
            node
              .AddTopNavigationNode(microsoft)
              .AddTopNavigationNode(apple);
        });
});
 
DeployModel(model);
```