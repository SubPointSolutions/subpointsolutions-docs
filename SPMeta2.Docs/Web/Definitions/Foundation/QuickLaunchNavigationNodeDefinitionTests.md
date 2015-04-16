<!-- M2-TODO -->
<properties
	  pageTitle="QuickLaunchNavigationNodeDefinition"
    pageName="QuickLaunchNavigationNodeDefinition"
    parentPageId="12771"
/>

###Provision scenario
We should be able to provision a quick launch navigation.

###Scope
Should be deployed under web.

###Implementation
Quick launch navigation is enabled via QuickLaunchNavigation object.

Both CSOM/SSOM object models are supported. 
Provision checks if object exists looking up it by Url/Name property, then creates a new one. 
You can deploy either single site field or a set of the field using AddField() extension method as per following examples.

We suggest to use BuiltInFieldTypes to benefit OOTB SharePoint field types.

[LIST.SAMPLES]