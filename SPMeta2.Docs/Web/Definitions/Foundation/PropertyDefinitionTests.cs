using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Attributes;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Consts;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class PropertyDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.PropertyDefinition")]

        [SampleMetadata(
            Title = "Adding to farm",
            Description = "",
            Order = 20,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.PropertyBags)]

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

        [SampleMetadata(
            Title = "Adding to site",
            Description = "",
            Order = 50,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.PropertyBags)]

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

        [SampleMetadata(
            Title = "Adding to web",
            Description = "",
            Order = 60,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.PropertyBags)]

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

        [SampleMetadata(
            Title = "Adding to list",
            Description = "",
            Order = 70,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.PropertyBags)]

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
                CustomUrl = "ListWithProperties"
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

        [SampleMetadata(
            Title = "Adding to folder",
            Description = "",
            Order = 80,
            CatagoryAlias = SampleCategory.SharePointFoundation,
            GroupAlias = SampleGroups.PropertyBags)]

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
                CustomUrl = "ListWithProperties"
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