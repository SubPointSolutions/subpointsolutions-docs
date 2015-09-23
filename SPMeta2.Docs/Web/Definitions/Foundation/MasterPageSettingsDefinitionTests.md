<properties
	  pageTitle="MasterPageSettingsDefinition"
    pageName="MasterPageSettingsDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to setup both "Site" and "System" master page settings for a web site.

###Scope
Should be deployed under web.

###Implementation
Master page changes provision is enabled via MasterPageSettingsDefinition object.

Both CSOM/SSOM object models are supported. Provision updates SiteMasterPageUrl/SystemMasterPageUrl  values of the a target web site. AddMasterPageSettings() extension method as per following examples.

SiteMasterPageUrl and SystemMasterPageUrl are promted to the target web site. Both should be site relative URLs, as follow:

* /_catalogs/masterpage/seattle.master
* /_catalogs/masterpage/oslo.master

BuiltInMasterPageDefinitions class could be used to refer OOTB master pages.

[LIST.SAMPLES]