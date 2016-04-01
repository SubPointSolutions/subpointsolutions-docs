<properties
	  pageTitle="WebPartPageDefinition"
    pageName="WebPartPageDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a single web part page with OOTB or custon layout.

###Scope
Should be deployed under list or folder.

###Implementation
Web part page provision via WebPartPageDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if artifact exists looking up it by FileName property, then creates a new site field. 
You can deploy either single page or a set of the pages using AddWebPartPage() extension method as per following examples.

We suggest to use BuiltInWebPartPageTemplates to address PageLayoutTemplate property. Use CustomPageLayout in case you need a custom web part page template.

[LIST.SAMPLES]