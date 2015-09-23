<properties
	  pageTitle="QuickLaunchNavigationNodeDefinition"
    pageName="QuickLaunchNavigationNodeDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision the quick launch navigation.

###Scope
Should be deployed under web.

###Implementation
Quick launch navigation is enabled via QuickLaunchNodeNavigation object.

Both CSOM/SSOM object models are supported. 
Provision checks if object exists looking up it by Url/Title property, then creates a new one. 
You can deploy either single node or a set of the nodes using AddQuickLaunchNavigationNode() extension method as per following examples.

[LIST.SAMPLES]