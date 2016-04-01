<properties
	pageTitle="SP2013WorkflowSubscriptionDefinition"
    pageName="SP2013WorkflowSubscriptionDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to bind SharePoint 2013 workflow to a web or list in a nice, repeatable way.

###Scope
Should be deployed under web or list.

###Implementation
SharePoint 2013 workflow binding to a web or list is enabled via SP2013WorkflowSubscriptionDefinition object.

Both CSOM/SSOM object models are supported. 
Provision checks if object exists looking up it by Name property, then creates a new object. 
You can deploy either single object or a set of the objects using AddSP2013WorkflowSubscription() extension method as per following examples

[LIST.SAMPLES]