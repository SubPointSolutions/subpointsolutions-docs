using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;


using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]

    [Category("Category=Site Collection Model/Security")]
    //[Browsable(false)]

    public class SecurityGroupLinkDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.SecurityGroupLinkDefinition")]

        [DisplayName("Assign security group to web")]
        //[Browsable(false)]
        public void CanDeploySimpleSecurityGroupLinkDefinitionToWeb()
        {
            var auditors = new SecurityGroupDefinition
            {
                Name = "External Auditors",
                Description = "External auditors group."
            };

            // add group to the site first
            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddSecurityGroup(auditors);
            });

            // assign group to the web, via .AddSecurityGroupLink() method
            var webModel = SPMeta2Model.NewWebModel(web =>
            {

                web.AddSecurityGroupLink(auditors);
            });

            DeployModel(siteModel);
            DeployModel(webModel);
        }

        [DisplayName("Assign security group to list")]
        //[Browsable(false)]
        public void CanDeploySimpleSecurityGroupLinkDefinitionToList()
        {
            var auditors = new SecurityGroupDefinition
            {
                Name = "External Auditors",
                Description = "External auditors group."
            };

            var auditorsList = new ListDefinition
            {
                Title = "Auditors documents",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                CustomUrl = "audit-docs"
            };

            // add group to the site first
            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddSecurityGroup(auditors);
            });

            // assign group to the list, via .AddSecurityGroupLink() method
            var webModel = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(auditorsList, list =>
                {
                    list.AddSecurityGroupLink(auditors);
                });
            });

            DeployModel(siteModel);
            DeployModel(webModel);
        }

        #endregion
    }
}