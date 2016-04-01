<properties
	pageTitle="XsltListViewWebPartDefinition"
    pageName="XsltListViewWebPartDefinition"
    parentPageId="spmeta2/definitions/sharepoint-foundation/webparts"
/>

###Provision scenario
We should be able to provision XsltListViewWebPart in a nice, repeatable way.

###Scope
Should be deployed under wiki, web part or publishing page.

###Implementation
XsltListViewWebPart provision is enabled via XsltListViewWebPartDefinition object.

Both CSOM/SSOM object models are supported. 
You can deploy either single object or a set of the objects using AddXsltListViewWebPart() extension method as per following examples

[LIST.SAMPLES]