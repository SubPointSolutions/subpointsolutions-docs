<properties
	  pageTitle="ListViewDefinition"
    pageName="ListViewDefinition"
        parentPageId="spmeta2/definitions/sharepoint-foundation"
/>

###Provision scenario
We should be able to provision a SharePoint list view.

###Scope 
Can be added under list.

###Implementation
List view provision is enabled via ListViewDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if list view exists looking up it by Url property, then by Title, and the creates a new list definition. You can deploy either single list view or a set of the list views using AddListView() extension method as per following examples.

[LIST.SAMPLES]