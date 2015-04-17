using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Standard.Definitions.Taxonomy;
using SPMeta2.Syntax.Default;
using SPMeta2.Standard.Syntax;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class TaxonomyTermDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
         Title = "Adding terms",
         Description = "",
         Order = 200,
         CatagoryAlias = SampleCategory.SharePointStandard,
         GroupAlias = SampleGroups.TermStore)]
        [TestMethod]
        [TestCategory("Docs.TaxonomyTermDefinition")]
        public void CanDeploySimpleTaxonomyTerms()
        {
            // define term store
            var defaultSiteTermStore = new TaxonomyTermStoreDefinition
            {
                UseDefaultSiteCollectionTermStore = true
            };

            // define group
            var clientsGroup = new TaxonomyTermGroupDefinition
            {
                Name = "Clients"
            };

            // define term sets
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

            // define terms
            var microsoft = new TaxonomyTermDefinition
            {
                Name = "Microsoft"
            };

            var apple = new TaxonomyTermDefinition
            {
                Name = "Apple"
            };

            var oracle = new TaxonomyTermDefinition
            {
                Name = "Oracle"
            };

            var subPointSolutions = new TaxonomyTermDefinition
            {
                Name = "SubPoint Solutions"
            };

            // setup the model 
            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddTaxonomyTermStore(defaultSiteTermStore, termStore =>
                {
                    termStore.AddTaxonomyTermGroup(clientsGroup, group =>
                    {
                        group
                            .AddTaxonomyTermSet(smallBusiness, termSet =>
                            {
                                termSet.AddTaxonomyTerm(subPointSolutions);
                            })
                            .AddTaxonomyTermSet(mediumBusiness)
                            .AddTaxonomyTermSet(enterpriseBusiness, termSet =>
                            {
                                termSet
                                    .AddTaxonomyTerm(microsoft)
                                    .AddTaxonomyTerm(apple)
                                    .AddTaxonomyTerm(oracle);
                            });
                    });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}