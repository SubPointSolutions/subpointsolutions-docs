<!-- M2-TODO -->
<properties
	  pageTitle="WebPartPageDefinition"
    pageName="WebPartPageDefinition"
    parentPageId="12771"
/>

###Provision scenario
We should be able to provision a single web part page with OOTB or custon layout.

###Scope
Should be deployed under list.

###Implementation
Site field provision is enabled via FieldDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if field exists looking up it by Id/Name property, then creates a new site field. You can deploy either single site field or a set of the field using AddField() extension method as per following examples.

We suggest to use BuiltInFieldTypes to benefit OOTB SharePoint field types.

###Samples
A SAMPLE 1
[TEST.TestFunctionName1]

A SAMPLE 2
[TEST.TestFunctionName2]

###Links
- [link 1](http://example.com)
- [link 2](http://example.com)