<properties
	pageTitle="SPMeta2 1.1.80, Apr 2015"
    pageName="spmeta2-v1180"
    parentPageId="3761"
/>

### Summary
Publishing fields support, XML/JSON serialization support for models, improving lookup/taxonomy fields provision, adding other enhancements and reaching 400+ regression tests. [Updated documentation](http://docs.subpointsolutions.com/spmeta2/) and new [scenarios page](http://docs.subpointsolutions.com/spmeta2/scenarios/). 

### New definitions
* WebPartGalleryFileDefinition
* ControlDisplayTemplateDefinition
* ItemDisplayTemplateDefinition
* JavaScriptDisplayTemplateDefinition
* LinkFieldDefinition
* ImageFieldDefinition
* HTMLFieldDefinition
* SummaryLinkFieldDefinition
* MediaFieldDefinition
* OutcomeChoiceFieldDefinition
* GeolocationFieldDefinition
* SummaryLinkWebPartDefinition
* UserCodeWebPartDefinition (sandbox web parts, only SSOM)
* DeleteWebPartDefinition 

### Fixes
* Correct parent-child content type sorting during provision
* Correct DateTimeFieldDefinition provision (CalendarType/DisplayFormat/FriendlyDisplayFormat props issue)
* ListViewDefinition fixes for top folder/content type bindings

### Enhancements
* Lookup/Taxonomy fields can be deployed with empty bindings
* BuiltInFolderDefinitions contans 'Master page gallery' folders
* OnCreatingContext contains ModelHost object
* PublishingPageDefinition has DefaultValues prop to enable provision with required properties
* Fields can be provisioned under web (web scoped fields)
* Content types can be provisioned under web (web scoped content types)
* TaxonomyTermSetDefinition has IsOpenForTermCreation prop
* TaxonomyFieldDefinition has IsPathRendered prop
* ContentTypeDefinition has better document template provision
* ModuleFileDefinition has DefaultValues/ContentTypeName/ContentTypeId props
* spmeta2.csom.utils class included into the main library
* WelcomePageDefinition handles starting '/' (amazing SharePoint API) 
* ListDefinition has MajorWithMinorVersionsLimit/MajorVersionLimit props (SSOM only)
* FieldDefinition has EnforceUniqueValues prop
* FieldDefinition has ShowInEditForm/ShowInNewForm/ShowInListForm props
* JSOM/XML serialization support for models (based on DataContractSerializer)
* Model validation on required properties 
* VS IntelliSense support - XML comments are included into NuGet packages
* TaxonomyTermSetDefinition.IsAvailableForTagging chaned to bool?
* Improved taxonomy navigation (CanDeploy_WebNavigationSettings_As_TaxonomyProvider)

### Documentation
Updated documentation is available here - http://docs.subpointsolutions.com/spmeta2

Get familiar with the [basics concepts](http://docs.subpointsolutions.com/spmeta2/), [get started](http://docs.subpointsolutions.com/spmeta2/basics/getting-started/) and check out [scenarios page](http://docs.subpointsolutions.com/spmeta2/scenarios/). That would save the day. We continuously updating the content, but let us know if you miss something right now.

### Upcoming release - November 2014 CSOM runtime upgrade
The upcoming May 2015 release will shift CSOM assemblies from SP2013 SP1 to November 2014 CU due to support ListDefinition MajorWithMinorVersionsLimit/MajorVersionLimit props for CSOM. 

This release was heavily influenced by the community feedback and suggestions in both [Yammer](https://www.yammer.com/spmeta2feedback) and [UserVoice](https://subpointsolutions.uservoice.com). We constantly listen to the community enhancing SPMeta2 library with new features and enhancements.
