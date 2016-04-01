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
    public class TaxonomyTermSetDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
           Title = "Adding term sets",
           Description = "",
           Order = 100,
           CatagoryAlias = SampleCategory.SharePointStandard,
           GroupAlias = SampleGroups.TermStore)]
        [TestMethod]
        [TestCategory("Docs.TaxonomyTermSetDefinition")]
        public void CanDeploySimpleTaxonomyTermSets()
        {
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
        }

        #endregion
    }
}