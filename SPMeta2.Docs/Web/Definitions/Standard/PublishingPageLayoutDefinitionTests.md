<properties
	pageTitle="PublishingPageLayoutDefinition"
    pageName="PublishingPageLayoutDefinition"
    parentPageId="spmeta2/definitions/sharepoint-standard"
/>

###Provision scenario
We should be able to provision a publishing page layout.

###Scope
Should be deployed under the master page gallery list.

###Implementation
Publishing page layout provision is enabled via PublishingPageLayoutDefinition object.

Both CSOM/SSOM object models are supported.
Provision checks if a publishing page layout exists looking up it by FileName property, then creates a new one. 
You can deploy either single object or a set of the object using AddPublishingPageLayout() extension method as per following examples.

We suggest to use BuiltInListDefinitions.Calalogs.MasterPage to resolve built-in master page gallery list.

[LIST.SAMPLES]