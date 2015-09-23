<properties
    pageTitle="UserCustomActionDefinition"
    pageName="UserCustomActionDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision user custom action.

###Scope
Should be deployed under site, web or list.

###Implementation
User custom action provision is enabled via UserCustomActionDefinition object.

Both CSOM/SSOM object models are supported. 
Provision checks if object exists looking up it by Name property, then creates a new object. 
You can deploy either single object or a set of the objects using AddUserCustomAction() extension method as per following examples.

[LIST.SAMPLES]