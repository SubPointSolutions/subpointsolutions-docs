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
    public class TaxonomyTermGroupDefinitionTests : ProvisionTestBase
    {
        #region methods

        [SampleMetadata(
            Title = "Adding term group",
            Description = "",
            Order = 10,
            CatagoryAlias = SampleCategory.SharePointStandard,
            GroupAlias = SampleGroups.TermStore)]

        [TestMethod]
        [TestCategory("Docs.TaxonomyTermGroupDefinition")]
        public void CanDeploySimpleTaxonomyGroup()
        {
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
        }

        [SampleMetadata(
            Title = "Adding multiple term group",
            Description = "",
            Order = 10,
            CatagoryAlias = SampleCategory.SharePointStandard,
            GroupAlias = SampleGroups.TermStore)]
        [TestMethod]
        [TestCategory("Docs.TaxonomyTermGroupDefinition")]
        public void CanDeploySimpleTaxonomyGroups()
        {
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
        }

        #endregion
    }
}