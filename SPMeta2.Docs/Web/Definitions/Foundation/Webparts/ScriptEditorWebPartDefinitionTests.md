<properties
	pageTitle="ScriptEditorWebPartDefinition"
    pageName="ScriptEditorWebPartDefinition"
    parentPageId="spmeta2/definitions/sharepoint-foundation/webparts"
/>

###Provision scenario
We should be able to provision ScriptEditorWebPart in a nice, repeatable way.

###Scope
Should be deployed under wiki, web part or publishing page.

###Implementation
ScriptEditorWebPart provision is enabled via ScriptEditorWebPartDefinition object.

Both CSOM/SSOM object models are supported. 
You can deploy either single object or a set of the objects using AddScriptEditorWebPart() extension method as per following examples

Be aware that ID property must be more than 32 chars, that's a SharePoint API issues.

[LIST.SAMPLES]