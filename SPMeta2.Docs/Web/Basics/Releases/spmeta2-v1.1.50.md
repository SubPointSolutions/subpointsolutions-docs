<properties
	pageTitle="SPMeta2 1.1.50, Feb 2015"
    pageName="spmeta2-v1150"
    parentPageId="3761"
/>

### Summary

### New definitions
* ‘URL’ field definition
* ‘RegionalSettings’ definition
* ‘SearchSchema’ definition
* ‘ContentDatabase’ definition
* ‘WebConfigModification’ definition
* ‘InformationRightsManagementSettings’ definition
* ‘SecureStore/TargetAplication’ definitions
* ‘AlternateUrl’ definition
* ‘TreeViewSettings’ definition
* ‘PublishingPageLayout’ definition
* ‘RootWeb’ definition

### Improvements & enhancements
* StandardCSOMProvisionService/StandardSSOMProvisionService classes for "standard" artifacts provision (SharePoint Standard+)
* Enhanced sandbox solution provision (SiteAsset library is not used anhymore)
* Multi-target build for NuGet – .NET4 and .NET 4.5 are included in the NuGet pckages
* ‘BuiltInPublishingFieldTypes’ enumeration
* ‘RawXml’/’AdditionalAttributes’ properties for FieldDefinition
* Correct ‘AllowMultipleValues’ property provision for Lookup field
* ContentTypeFieldLinkDefinition enhancements with Hidden/Required/DisplayName props
* Correct ‘IsMult’ property provision for TaxonomyFieldDefinition
* Multiple fixed for TermGroup, TermSet and Term definitions
* Strong names for CSOM based assemblies
* ‘IsAvailableForTagging/Description for taxonomy definitions
* Correct nested terms privisoin
* Correct module file provision under content type
* JSLink property for XsltListViewWebpartDefinition
* Navigation node provision enhancements – respect node order during provision
* Multiple level provision for navigation nodes
* Enhanced pages/files provision while page/file is unpublished/checkout

### Regression test coverage
It is becoming absolutely insane – more than 270 regression tests is run under CSOM/SSOM/O365 environments to ensure stellar quality of the provisioning flow. That’s hundred tests on top of December 2014 release.
