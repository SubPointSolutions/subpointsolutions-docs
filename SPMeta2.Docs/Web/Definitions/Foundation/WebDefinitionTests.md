<properties 
	pageTitle="WebDefinition" 
    pageName="webdefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a single SharePoint web site, a collection of the web sites and hierarchy of the web sites with given Title, Description, URL and web template.

###Scope 
Can be added under site or web.

###Implementation
Web provision is enabled via WebDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if a web site exists, then creates a new web site using provided definition. You can deploy either single web site or a hierarchy of the web sites using AddWeb() extension method and nesting as per following examples.

###Samples

#### Single web site provision
[TEST.CanDeploySimpleWeb]

#### Single web site provision
[TEST.CanDeploySimpleWebs]

#### Web hierarchy provision
[TEST.CanDeployHierarchicalWebs]