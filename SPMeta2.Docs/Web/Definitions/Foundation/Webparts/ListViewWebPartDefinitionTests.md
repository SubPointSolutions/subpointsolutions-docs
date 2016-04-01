<properties
	pageTitle="ListViewWebPartDefinition"
    pageName="ListViewWebPartDefinition"
    parentPageId="spmeta2/definitions/sharepoint-foundation/webparts"
/>

###Provision scenario
We should be able to provision ListViewWebPart in a nice, repeatable way.

###Scope
Should be deployed under wiki, web part or publishing page.

###Implementation
ListViewWebPart provision is enabled via ListViewWebPartDefinition object.

Both CSOM/SSOM object models are supported. 
You can deploy either single object or a set of the objects using AddListViewWebPart() extension method as per following examples

[LIST.SAMPLES]