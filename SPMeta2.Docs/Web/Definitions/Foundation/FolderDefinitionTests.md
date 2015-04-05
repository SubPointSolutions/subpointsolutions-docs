<properties 
	  pageTitle="FolderDefinition" 
    pageName="FolderDefinition"
    parentPageId="12771"
/>

###Provision scenario
We should be able to provision a single folder under SharePoint list and library.
Hierarchical folders should be supported as well.

###Scope
Folder can be deployed under list or other folder. 

###Implementation
Folders provision is enabled via FolderDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if folder exists looking up it by Name property, then creates a new folder. You can deploy either single folder or a set of the folder using AddFolder() extension method as per following examples. Folder nesting is supported as well.

###Samples

#### Simple folders sample
[TEST.CanDeploySimpleFolders]

#### Flat folders structure sample
[TEST.CanDeploySimpleFolderList]

#### Hierarchical folder structure sample 
[TEST.CanDeployHierarchicalFolderList]