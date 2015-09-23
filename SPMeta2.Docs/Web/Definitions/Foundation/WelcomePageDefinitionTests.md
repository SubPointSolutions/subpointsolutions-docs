<properties
	  pageTitle="WelcomePageDefinition"
    pageName="WelcomePageDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to setup a welcome page for the target site, library or folder.

###Scope
Should be deployed under a web, a list or a folder.

###Implementation
Welcome page provision is enabled via WelcomePageDefinition object.

Both CSOM/SSOM object models are supported. Using the only property Url, provision updates WelcomePage property for a target artifact - web, list or folder.
Url should be object-related, a web related for the web, a list related and folder related for list and web accordingly.

[LIST.SAMPLES]