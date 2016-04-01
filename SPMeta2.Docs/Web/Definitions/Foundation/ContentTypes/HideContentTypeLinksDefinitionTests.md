<properties
	  pageTitle="HideContentTypeLinksDefinition"
    pageName="HideContentTypeLinksDefinition"
    parentPageId="spmeta2/definitions/sharepoint-foundation/contenttypes"
/>

###Provision scenario
We should be able to hide content types in the target list

###Scope
Should be deployed under the list.

###Implementation
Hiding content types inside a list is enabled via HideContentTypeLinksDefinition object.

Both CSOM/SSOM object models are supported. 
Provision makes fields non-required and hide them inside the content type according the Fields property. 
You can deploy either single object or a set of the objects using AddHideContentTypeLinks() extension method as per following examples.

[LIST.SAMPLES]