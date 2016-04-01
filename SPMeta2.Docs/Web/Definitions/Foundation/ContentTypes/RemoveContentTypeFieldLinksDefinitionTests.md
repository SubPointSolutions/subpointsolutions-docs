<properties
	pageTitle="RemoveContentTypeFieldLinksDefinition"
    pageName="RemoveContentTypeFieldLinksDefinition"
    parentPageId="spmeta2/definitions/sharepoint-foundation/contenttypes"
/>

###Provision scenario
We should be able to remove field in the target content type.

###Scope
Should be deployed under the content type.

###Implementation
Removing fields inside a content type is enabled via RemoveContentTypeFieldLinksDefinition object.

Both CSOM/SSOM object models are supported. 
Provision removed field link inside the content type according the Fields property. 
You can deploy either single object or a set of the objects using AddRemoveContentTypeFieldLinks() extension method as per following examples.

[LIST.SAMPLES]