<properties
	  pageTitle="SecurityRoleDefinition"
    pageName="SecurityRoleDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision SharePoint security role.

###Scope
Should be deployed under site.

###Implementation
Security role provision is enabled via SecurityRoleDefinition object.

Both CSOM/SSOM object models are supported. 
Provision checks if object exists looking up it by Name property, then creates a new object. 
You can deploy either single object or a set of the objects using AddSecurityRole() extension method as per following examples.

[LIST.SAMPLES]
