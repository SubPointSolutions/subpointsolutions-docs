using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Enumerations;
using SubPointSolutions.Docs.Code.Metadata;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]


    

    //[Browsable(false)]
    public class EventReceiverDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.EventReceiverDefinition")]

        [Category("Category=Site Collection Model/Event Receivers")]
        [DisplayName("Add event receiver to site")]
        [Browsable(false)]
        
        public void CanDeploySiteEventReceiverDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
         
            });

            DeployModel(model);
        }

        [Category("Category=Web Model/Event Receivers")]
        [DisplayName("Add event receiver to web")]
        [Browsable(false)]
        public void CanDeployWebSimpleEventReceiverDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {

            });

            DeployModel(model);
        }

        [Category("Category=Web Model/Event Receivers")]
        [DisplayName("Add event receiver to list")]
        [Browsable(false)]

        public void CanDeployListSimpleEventReceiverDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {

            });

            DeployModel(model);
        }

        [Category("Category=Site Collection Model/Event Receivers")]
        [DisplayName("Add event receiver to content type")]
        [Browsable(false)]
        public void CanDeployContentTypeSimpleEventReceiverDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {

            });

            DeployModel(model);
        }

        #endregion
    }
}