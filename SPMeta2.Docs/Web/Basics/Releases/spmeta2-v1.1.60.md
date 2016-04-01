<properties
	pageTitle="SPMeta2 1.1.60, Feb 2015"
    pageName="spmeta2-v1160"
    parentPageId="3761"
/>

### Summary

### New definitions
* ‘AuditingSettings’ definition

### Improvements & enhancements
* Better O365 support: new v16 NuGet packages for O365 CSOM v16 runtime
* Experimental SP2010 SSOM support: new v14 NuGet packages for SP2010 SSOM runtime
* PrpertyDefinition provision on farm/webapp leves
* Security group provision enhancements – AllowMembersEditMembership, AllowRequestToJoinLeave, AutoAcceptRequestToJoinLeave properties
* Added ‘BasicWebParts’ feature definitions for BuiltInSiteFeatures enumeration
* UserCustomActionDefinition definition enhancement – CommandUIExtension property
* Better field provision, correct processing for ValidationMessage/ValidationFormula properties
* ListDefinition enhancements – add ‘CustomUrl’ property
* LookupFieldDefinition enhancements – LookupListTitle, LookupListUrl, LookupList properties
* FieldDefinition/ListFieldLinkDefinition enhancements, AddFieldOptions option
* XsltListViewWebPartDefinition enhancements for SSOM

### Regression test coverage
Test coverage was significantly improved. It is becoming absolutely insane – more than 310+ regression tests is run under CSOM/SSOM/O365 environments to ensure stellar quality of the provisioning flow. That’s 40+ more tests on top of January 2015 release.