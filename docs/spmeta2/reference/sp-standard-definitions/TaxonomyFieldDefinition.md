---
id: "taxonomyfielddefinition"
title: "TaxonomyFieldDefinition "
scenario_model: "Web model"
scenario_category: "Fields"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
List

## Notes

Taxonomy field provision is enabled via TaxonomyFieldDefinition object.

Both CSOM/SSOM object models are supported. 
You can deploy either single object or a set of the objects using AddTaxonomyField() extension method as per following examples.

The following properties allow to adjust the desired field configuration:

* **UseDefaultSiteCollectionTermStore**, indicates that the default site taxonomy store needs to be used
* **SspId**, ID of the target taxonomy store
* **SspName**, Name of the target taxonomy store
* **IsMulti**, allows multiple choices option for the field
* **TermSetName**, term set name to be bind to the field
* **TermSetId**, term set id to be bind to the field
* **TermName**, term name to be bind to the field
* **TermId**, term id to be bind to the field
* **IsPathRendered**, indicated path rendering,
* **CreateValuesInEditForm**, allows to create new values in the edit form,
* **Open**, indicates that the term is open


## Examples

### Add taxonomy field

```cs
// define a taxonomy
// term store -> group -> term set -> terms
var taxDefaultTermStore = new TaxonomyTermStoreDefinition
{
    UseDefaultSiteCollectionTermStore = true
};
 
var taxTermGroup = new TaxonomyTermGroupDefinition
{
    Name = "SPMeta2 Taxonomy"
};
 
var taxTermSet = new TaxonomyTermSetDefinition
{
    Name = "Locations"
};
 
var taxTermLondon = new TaxonomyTermDefinition
{
    Name = "London"
};
 
var taxTermSydney = new TaxonomyTermDefinition
{
    Name = "Sydney"
};
 
// define the field
var location = new TaxonomyFieldDefinition
{
    Title = "Location",
    InternalName = "dcs_LocationTax",
    Group = "SPMeta2.Samples",
    Id = new Guid("FE709AC2-E3A1-4A25-8F71-3480667CD98F"),
    IsMulti = false,
    UseDefaultSiteCollectionTermStore = true,
    TermSetName = taxTermSet.Name
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddHostTaxonomyTermStore(taxDefaultTermStore, store =>
        {
            store.AddTaxonomyTermGroup(taxTermGroup, group =>
            {
                group.AddTaxonomyTermSet(taxTermSet, termSet =>
                {
                    termSet
                        .AddTaxonomyTerm(taxTermLondon)
                        .AddTaxonomyTerm(taxTermSydney);
                });
            });
        })
        .AddTaxonomyField(location);
});
 
DeployModel(model);
```