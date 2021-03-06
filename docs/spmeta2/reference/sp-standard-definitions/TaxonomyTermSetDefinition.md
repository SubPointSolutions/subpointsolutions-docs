---
id: "taxonomytermsetdefinition"
title: "TaxonomyTermSetDefinition"
scenario_model: "Web model"
scenario_category: "Taxonomy"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
List

## Notes
Both CSOM/SSOM object models are supported.

Provision checks if term set exists, and then creates a new one.

## Examples

### Add taxonomy termsets

```cs
var defaultSiteTermStore = new TaxonomyTermStoreDefinition
{
    UseDefaultSiteCollectionTermStore = true
};
 
var clientsGroup = new TaxonomyTermGroupDefinition
{
    Name = "Clients"
};
 
var smallBusiness = new TaxonomyTermSetDefinition
{
    Name = "Small Business"
};
 
var mediumBusiness = new TaxonomyTermSetDefinition
{
    Name = "Medium Business"
};
 
var enterpriseBusiness = new TaxonomyTermSetDefinition
{
    Name = "Enterprise Business"
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddTaxonomyTermStore(defaultSiteTermStore, termStore =>
    {
        termStore.AddTaxonomyTermGroup(clientsGroup, group =>
        {
            group
                .AddTaxonomyTermSet(smallBusiness)
                .AddTaxonomyTermSet(mediumBusiness)
                .AddTaxonomyTermSet(enterpriseBusiness);
        });
    });
});
 
DeployModel(model);
```
