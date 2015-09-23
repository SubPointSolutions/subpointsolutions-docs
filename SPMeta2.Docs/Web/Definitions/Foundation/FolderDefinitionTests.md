<properties 
	  pageTitle="FolderDefinition" 
    pageName="FolderDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a single folder under SharePoint list and library.
Hierarchical folders should be supported as well.

###Scope
Folder can be deployed under list or other folder. 

###Implementation
Folders provision is enabled via FolderDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if folder exists looking up it by Name property, then creates a new folder. You can deploy either single folder or a set of the folder using AddFolder() extension method as per following examples. Folder nesting is supported as well.

[LIST.SAMPLES]