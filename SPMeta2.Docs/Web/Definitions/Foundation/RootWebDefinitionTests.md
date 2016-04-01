<properties
	  pageTitle="RootWebDefinition"
    pageName="RootWebDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to start provision from the root web as well as update Title/Description properties.

###Scope
Should be deployed under site.

###Implementation
Root web provision is enabled via RootWebDefinition object.

There are two cases for which RootWebDefinition could be of use:

* We need to rename Title/Description of the root web
* We need to 'lookup' the root web to provision content on root web

If Title/Description are not provided, provision does not change anything.

Both CSOM/SSOM object models are supported. 

[LIST.SAMPLES]