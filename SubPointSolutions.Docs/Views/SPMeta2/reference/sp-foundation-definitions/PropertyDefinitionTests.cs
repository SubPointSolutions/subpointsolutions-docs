using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Enumerations;
using SubPointSolutions.Docs.Code.Metadata;
using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]


    //[Browsable(false)]
    public class PropertyDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.PropertyDefinition")]

        [Category("Category=Farm Model/Property bags")]
        [DisplayName("Add property to farm")]
        //[Browsable(false)]
        public void CanDeployPropertyBagUnderFarm()
        {
            var farmTag = new PropertyDefinition
            {
                Key = "m2_farm_tag",
                Value = "m2_farm_tag_value",
            };

            var farmType = new PropertyDefinition
            {
                Key = "m2_farm_type",
                Value = "m2_farm_type_value",
            };

            var model = SPMeta2Model.NewFarmModel(farm =>
            {
                farm
                    .AddProperty(farmTag)
                    .AddProperty(farmType);
            });

            DeploySSOMModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.PropertyDefinition")]


        [Category("Category=Site Collection Model/Property bags")]
        [DisplayName("Add property to site")]
        //[Browsable(false)]
        public void CanDeployPropertyBagUnderSite()
        {
            var siteTag = new PropertyDefinition
            {
                Key = "m2_site_tag",
                Value = "m2_site_tag_value",
            };

            var siteType = new PropertyDefinition
            {
                Key = "m2_site_type",
                Value = "m2_site_type_value",
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddProperty(siteTag)
                    .AddProperty(siteType);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.PropertyDefinition")]

        [Category("Category=Web Model/Property bags")]

        [DisplayName("Add property to web")]
        //[Browsable(false)]
        public void CanDeployPropertyBagUnderWeb()
        {
            var webTag = new PropertyDefinition
            {
                Key = "m2_web_tag",
                Value = "m2_web_tag_value",
            };

            var webType = new PropertyDefinition
            {
                Key = "m2_web_type",
                Value = "m2_web_type_value",
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                 .AddProperty(webTag)
                 .AddProperty(webType);
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.PropertyDefinition")]
        
        [Category("Category=Web Model/Property bags")]

        [DisplayName("Add property to list")]
        //[Browsable(false)]
        public void CanDeployPropertyBagUnderList()
        {
            var listTag = new PropertyDefinition
            {
                Key = "m2_list_tag",
                Value = "m2_list_tag_value",
            };

            var listType = new PropertyDefinition
            {
                Key = "m2_web_type",
                Value = "m2_web_type_value",
            };

            var listWithProperties = new ListDefinition
            {
                Title = "List with properties",
                Description = "List with some properties.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                Url = "ListWithProperties"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(listWithProperties, list =>
                {
                    list
                      .AddProperty(listTag)
                      .AddProperty(listType);
                });
            });

            DeployModel(model);
        }


        [TestMethod]
        [TestCategory("Docs.PropertyDefinition")]

        [Category("Category=Web Model/Property bags")]

        [DisplayName("Add property to folder")]
        //[Browsable(false)]
        public void CanDeployPropertyBagUnderFolder()
        {
            var folderTag = new PropertyDefinition
            {
                Key = "m2_folder_tag",
                Value = "m2_folder_tag_value",
            };

            var folderType = new PropertyDefinition
            {
                Key = "m2_folder_type",
                Value = "m2_folder_type_value",
            };

            var listWithProperties = new ListDefinition
            {
                Title = "List with properties",
                Description = "List with some properties.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                Url = "ListWithProperties"
            };

            var fodlerWithProperties = new FolderDefinition
            {
                Name = "folder with properties"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(listWithProperties, list =>
                {
                    list.AddFolder(fodlerWithProperties, folder =>
                    {
                        // Syntax miss - folder should support adding props #669 
                        // https://github.com/SubPointSolutions/spmeta2/issues/669

                        //folder
                        //    .AddProperty(folderTag)
                        //    .AddProperty(folderType);

                        folder
                            .AddDefinitionNode(folderTag)
                            .AddDefinitionNode(folderType);
                    });

                });
            });

            DeployModel(model);
        }

        #endregion
    }
}