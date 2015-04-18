<properties
	pageTitle="SiteFeedWebPartDefinition"
    pageName="SiteFeedWebPartDefinition"
    parentPageId="48531"
/>


###Provision scenario
We should be able to provision SiteFeedWebPart in a nice, repeatable way.

###Scope
Should be deployed under wiki, web part or publishing page.

###Implementation
ScriptEditorWebPart provision is enabled via SiteFeedWebPartDefinition object.

Both CSOM/SSOM object models are supported. 
You can deploy either single object or a set of the objects using AddSiteFeedWebPart() extension method as per following examples

[LIST.SAMPLES]