using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;



namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    

     [Category("Category=Web Model/Lists and libraries")]

    //[Browsable(false)]
    public class ListItemDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.ListItemDefinition")]

        [DisplayName("Add list item")]
        //[Browsable(false)]
        public void CanDeploySimpleListItemDefinition()
        {
            var listDef = new ListDefinition
            {
                Title = "Customers",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                CustomUrl = "lists/customers",
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(listDef, list =>
                {
                    list
                        .AddListItem(new ListItemDefinition { Title = "Microsoft" })
                        .AddListItem(new ListItemDefinition { Title = "Apple" })
                        .AddListItem(new ListItemDefinition { Title = "IBM" });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}