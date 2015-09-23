<properties 
	pageTitle="ListDefinition" 
    pageName="listdefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a single SharePoint list or library.

###Scope 
Can be added under web.

###Implementation
List and library provision is enabled via ListDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if list exists looking up it by Url property, then creates a new list. You can deploy either single list or a set of the lists using AddList() extension method as per following examples.

[LIST.SAMPLES]