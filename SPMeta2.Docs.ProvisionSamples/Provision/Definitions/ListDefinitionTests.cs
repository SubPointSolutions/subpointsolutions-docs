using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class ListDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.ListDefinition")]
        public void CanDeploySimpleLists()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWeb(DocWebs.AboutOurCompany, aboutWeb =>
                    {
                        aboutWeb
                            .AddList(DocLists.AboutUsLists.ManagementTeam)
                            .AddList(DocLists.AboutUsLists.OurClients);
                    })
                    .AddWeb(DocWebs.DepartmentWebs.HR, hrWeb =>
                    {
                        hrWeb
                            .AddList(DocLists.HRLists.AnnualReviews)
                            .AddList(DocLists.HRLists.Poicies)
                            .AddList(DocLists.HRLists.Procedures);
                    })
                    .AddWeb(DocWebs.Departments, departmentWeb =>
                    {
                        departmentWeb
                            .AddList(DocLists.DepartmentsLists.IssueRegister)
                            .AddList(DocLists.DepartmentsLists.TeamEvents)
                            .AddList(DocLists.DepartmentsLists.TeamTasks);
                    });
            });

            DeployModel(model);
        }

        #endregion
    }
}
