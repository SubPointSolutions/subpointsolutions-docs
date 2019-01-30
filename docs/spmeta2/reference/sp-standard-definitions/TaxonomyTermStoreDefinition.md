---
id: "taxonomytermstoredefinition"
title: "TaxonomyTermStoreDefinition"
scenario_model: "Web model"
scenario_category: "Taxonomy"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
List

## Notes
Term store lookup is enabled via TaxonomyTermStoreDefinition object.

Both CSOM/SSOM object models are supported.

Provision used Name, Id or UseDefaultSiteCollectionTermStore properties to lookup **existing termstore**.

## Examples

### Add taxonomy term store by Name

```cs
var mmsTermStore = new TaxonomyTermStoreDefinition
{
    Name = "Managed Metadata Service"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddTaxonomyTermStore(mmsTermStore, termStore =>
    {
        // do stuff, add groups, term sets
    });
});
 
DeployModel(model);

```

### Add default taxonomy term store


```cs
var defaultSiteTermStore = new TaxonomyTermStoreDefinition
{
    UseDefaultSiteCollectionTermStore = true
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddTaxonomyTermStore(defaultSiteTermStore, termStore =>
    {
        // do stuff, add groups, term sets
    });
});
 
DeployModel(model);
```