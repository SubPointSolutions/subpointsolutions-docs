<properties 
	  pageTitle="ContentTypeDefinition" 
    pageName="ContentTypeDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a SharePoint content type.

###Scope
Should be deployed under site or web models.

###Implementation
Content type provision is enabled via ContentTypeDefinition object.

Both CSOM/SSOM object models are supported (CSOM requires SP2013 SP1). Provision checks if content type exists looking up it by ID property, then creates a new content type. You can deploy either single content type or a set of the content types using AddContentType() extension method as per following examples.

GetContentTypeId() extension methods can be used to calculate a parent content type while having a content type hierarchy as per “Customer Contract” content type below.

We suggest to use BuiltInContentTypeId to benefit OOTB SharePoint content type IDs.

[LIST.SAMPLES]