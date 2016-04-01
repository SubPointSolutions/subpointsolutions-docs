<properties 
	pageTitle="FieldDefinition" 
    pageName="FieldDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a single SharePoint site field as well as set of fields by given properties.

###Scope
Should be deployed under site or list.

###Implementation
Site field provision is enabled via FieldDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if field exists looking up it by Id/Name property, then creates a new site field. You can deploy either single site field or a set of the field using AddField() extension method as per following examples.

We suggest to use BuiltInFieldTypes to benefit OOTB SharePoint field types.

[LIST.SAMPLES]