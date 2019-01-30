---
id: "taxonomytermgroupdefinition"
title: "TaxonomyTermGroupDefinition"
scenario_model: "Web model"
scenario_category: "Taxonomy"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
List

## Notes
Both CSOM/SSOM object models are supported.

Provision checks if group exists, and then creates a new one.

## Examples

### Add taxonomy term group

```cs
var defaultSiteTermStore = new TaxonomyTermStoreDefinition
{
    UseDefaultSiteCollectionTermStore = true
};
 
var clientsGroup = new TaxonomyTermGroupDefinition
{
    Name = "Clients"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddTaxonomyTermStore(defaultSiteTermStore, termStore =>
    {
        termStore
            .AddTaxonomyTermGroup(clientsGroup);
    });
});
 
DeployModel(model);

```

### Add taxonomy term groups

```cs
var defaultSiteTermStore = new TaxonomyTermStoreDefinition
{
    UseDefaultSiteCollectionTermStore = true
};
 
var clientsGroup = new TaxonomyTermGroupDefinition
{
    Name = "Clients"
};
 
var parthersGroup = new TaxonomyTermGroupDefinition
{
    Name = "Parthers"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddTaxonomyTermStore(defaultSiteTermStore, termStore =>
    {
        termStore
            .AddTaxonomyTermGroup(clientsGroup)
            .AddTaxonomyTermGroup(parthersGroup);
    });
});
 
DeployModel(model);
```