using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class WebDefinitionTest : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.WebDefinition")]
        public void CanDeploySimpleWebs()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddWeb(DocWebs.News);
                web.AddWeb(DocWebs.AboutOurCompany);
            });

            DeployModel(model);
        }


        [TestMethod]
        [TestCategory("Docs.WebDefinition")]
        public void CanDeployHierarchicalWebs()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWeb(DocWebs.News)
                    .AddWeb(DocWebs.Departments, departmentWeb =>
                    {
                        departmentWeb
                            .AddWeb(DocWebs.DepartmentWebs.HR)
                            .AddWeb(DocWebs.DepartmentWebs.ITHelpDesk, itWeb =>
                            {
                                itWeb
                                    .AddWeb(DocWebs.DepartmentWebs.ITHelpDeskWebs.Apple)
                                    .AddWeb(DocWebs.DepartmentWebs.ITHelpDeskWebs.Cisco)
                                    .AddWeb(DocWebs.DepartmentWebs.ITHelpDeskWebs.Microsoft);
                            })
                            .AddWeb(DocWebs.DepartmentWebs.Sales);
                    })
                    .AddWeb(DocWebs.AboutOurCompany);
            });

            DeployModel(model);
        }

        #endregion
    }
}
