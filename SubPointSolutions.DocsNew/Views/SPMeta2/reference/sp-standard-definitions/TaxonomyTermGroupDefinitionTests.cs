using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Standard.Definitions.Taxonomy;
using SPMeta2.Syntax.Default;
using SPMeta2.Standard.Syntax;



namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    [Category("Category=Site Collection Model/ Taxonomy")]
    //[Browsable(false)]
    public class TaxonomyTermGroupDefinitionTests : ProvisionTestBase
    {
        #region methods

       

        [TestMethod]
        [TestCategory("Docs.TaxonomyTermGroupDefinition")]

        [DisplayName("Add taxonomy term group")]
        //[Browsable(false)]
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

      
        [TestMethod]
        [TestCategory("Docs.TaxonomyTermGroupDefinition")]
        [DisplayName("Add taxonomy term groups")]
        //[Browsable(false)]
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