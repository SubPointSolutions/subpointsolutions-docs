<properties
	pageTitle="SPMeta2 1.1.71, Mar 2015"
    pageName="spmeta2-v1171"
    parentPageId="3761"
/>

### Summary
Improved updatebility for lots of definitions so that property changes are reflected in SharePoint artefacts for the second and following provisions. New definitions and tests been added as well.

### New definitions
* MasterPageDefinition (ASP NET Master Page)
* ResetRoleInheritanceDefinition
* TaxonomyTermLabelDefinition

### Improvements & enhancements
* ‘Array’ overload for AddXXX() methods, for instance ‘AddFields(IEnumerable<>)’ and ‘AddLists(IEnumerable<>)’
* Strong typed extensions for CSOM/SSOM provision services – DeploySiteModel()/DeployWebModel()
* Fixed WebDefinition provision (does not drop Title/Description to String.Empty)
* Token support (~site/~sitecollection) for ContentEditorWebPartDefinition.ContentLink
* New enumeration – BuiltInPublishingContentTypeNames
* Enhanced ‘ListDefinition’ – draft option props
* Enhanced ‘TaxonomyTermGroupDefinition’ – IsSiteCollectionGroup prop
* Enhances ‘TaxonomyTermDefinition’ provision – supports nested ‘TaxonomyTermLabelDefinition’
* Enhanced feature definition provision (sandbox features support)
* Enhanced ‘UserFieldDefinition’ provision (SelectionGroup/SelectionGroupName props)
* Enhanced ‘XsltListViewWebPart’ provision – CSOM supports list views (!!)
* Covered by regression tests updatability on the following artifacts – ListDefinition, ContentTypeDefinition, ListViewDefinition, RootWebDefinition, SecurityGroupDefinition, SecurityRoleDefinition, TreeViewSettingsDefinition, TaxonomyTermGroupDefinition, TaxonomyTermDefinition, PublishingPageDefinition, WikiPageDefinition, WebPartPageDefinition, PublishingPageLayoutDefinition

### Regression test coverage
Test coverage is constantly improved. We have 340+ regression tests is run under CSOM/SSOM/O365 environments to ensure stellar quality of the provisioning flow. That’s 30+ more tests on top of February 2015 release.