<properties
	pageTitle="PropertyDefinition"
    pageName="PropertyDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a property bag value.

###Scope
Should be deployed under farm, web application, site collection, web, list or library.

###Implementation
Property bag value provision is enabled via PropertyDefinition object.

Both CSOM/SSOM object models are supported. SSOM also supports farm and web application scopes.
Provision updated a target property with given Key/Value pair. 
You can deploy either single mode or a set of the nodes using AddProperty() extension method as per following examples.

[LIST.SAMPLES]