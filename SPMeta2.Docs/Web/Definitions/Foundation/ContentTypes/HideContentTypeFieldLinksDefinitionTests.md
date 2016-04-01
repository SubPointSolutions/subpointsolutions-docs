<properties
	  pageTitle="HideContentTypeFieldLinksDefinition"
    pageName="HideContentTypeFieldLinksDefinition"
    parentPageId="spmeta2/definitions/sharepoint-foundation/contenttypes"
/>

###Provision scenario
We should be able to hide field in the target content type.

###Scope
Should be deployed under the content type.

###Implementation
Hiding fields inside a content type is enabled via HideContentTypeFieldLinksDefinition object.

Both CSOM/SSOM object models are supported. 
Provision makes fields non-required and hide them inside the content type according the Fields property. 
You can deploy either single object or a set of the objects using AddHideContentTypeFieldLinks() extension method as per following examples.

[LIST.SAMPLES]