using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Standard.Definitions.Taxonomy;
using SPMeta2.Syntax.Default;
using SPMeta2.Standard.Syntax;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class TaxonomyTermStoreDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.TaxonomyTermStoreDefinition")]
        public void LookupTermStoreByName()
        {
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
        }

        [TestMethod]
        [TestCategory("Docs.TaxonomyTermStoreDefinition")]
        public void LookupDefaultSiteTermStore()
        {
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
        }

        #endregion
    }
}