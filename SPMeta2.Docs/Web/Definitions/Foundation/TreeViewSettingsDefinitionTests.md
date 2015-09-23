<properties
	  pageTitle="TreeViewSettingsDefinition"
    pageName="TreeViewSettingsDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to setup tree view and quick launch settings for a target web site.

###Scope
Should be deployed under web.

###Implementation
Provision updates tree view and quick launch settings of the given web site.

Both CSOM/SSOM object models are supported. 
You can deploy either single object or a set of the objects using AddTreeViewSettings() extension method as per following examples.

[LIST.SAMPLES]