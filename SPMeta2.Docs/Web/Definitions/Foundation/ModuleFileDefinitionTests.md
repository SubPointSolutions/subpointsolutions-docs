<properties
	  pageTitle="ModuleFileDefinition"
    pageName="ModuleFileDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a module file.

###Scope
Should be deployed under a document library or content type.
In case of content type, a resource folder is used.

###Implementation
Module files provision is enabled via ModuleFileDefinition object.

Both CSOM/SSOM object models are supported. 
Provision checks if object exists looking up it by Name property, then creates a new object. 
You can deploy either single object or a set of the objects using AddModuleFile() extension method as per following examples.

[LIST.SAMPLES]