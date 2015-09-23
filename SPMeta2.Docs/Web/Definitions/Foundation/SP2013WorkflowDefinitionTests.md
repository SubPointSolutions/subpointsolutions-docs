<properties
	pageTitle="SP2013WorkflowDefinition"
    pageName="SP2013WorkflowDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision SharePoint 2013 workflow in a nice, repeatable way.

###Scope
Should be deployed under web.

###Implementation
SharePoint 2013 workflow provision is enabled via SP2013WorkflowDefinition object.

Both CSOM/SSOM object models are supported. 
Provision checks if object exists looking up it by DisplayName property, then creates a new object. 
You can deploy either single object or a set of the objects using AddSP2013Workflow() extension method as per following examples

[LIST.SAMPLES]