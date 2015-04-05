<properties
	pageTitle="Writing custom definition"
    pageName="writing-custom-definition"
    parentPageId="36872"
/>

This article provides basics on creating a custom definion and model handler for SPMeta2 library.

Before you begin, make sure you are familiar with the following concepts:

* [SPMeta2 basics](http://docs.subpointsolutions.com/spmeta2/basics/)
* [SPMeta2 definitions](http://docs.subpointsolutions.com/spmeta2/definitions/)

### Overview
SPMeta2 can be extended with custom definition and model handler, so that you can plug in your own provision logic.

Here is a big puctire on how SPMeta2 provision walks through the web model with lists and list views.

<img src='http://g.gravizo.com/g?

@startuml;

"web definition" -> "web definition": lookup handler;
"web definition" -> "web definition": DeployModel();
"web definition" -> "web definition": lookup children models;
"web definition" -> "list definition": WithResolvingModelHost(), get web instance;

"list definition" -> "list definition": lookup handler;
"list definition" -> "list definition": DeployModel();
"list definition" -> "list definition": lookup children models;
"list definition" -> "list view definition": WithResolvingModelHost(), get list instance;

"list view definition" -> "list view definition": lookup handler;
"list view definition" -> "list view definition": DeployModel();
"list view definition" -> "list definition": back;

"list definition" -> "web definition": back;
     
@enduml
'>

At the end, SPMeta2 provision service walks through the model tree resolving correct model handler and calling a pair of DeployModel() and WithResolvingModelHost() methods.

All model handlers must inherit ModelHandlerBase class and implement the following methods:

* DeployModel(object modelHost, DefinitionBase model) method
* TargetType property
* Optionally, WithResolvingModelHost(ModelHostResolveContext context) method

DeployModel() methods must also raise a pair of OnProvisioning / OnProvisioned event, so that it would be possible to get access to the raw SharePoint object during the provision.

Let's have a closer look and create a simple custom definition with model handler.

### Scenario
We need to have a custom defintion to change existing web title and description.

#### Creating definition
All definition should meet the following criterias:

* Inherit DefinitionBase class
* Have [Serializable] attribute

Here is how a custom ChangeWebTitleAndDescriptionDefinition might look like:

[CLASS.ChangeWebTitleAndDescriptionDefinition]

#### Creating model handlers
The next step would be creating a custom model handler:

[CLASS.ChangeWebTitleAndDescriptionModelHandler]

#### Registering model handler
One you created a custom model handler, we need to let SPMeta2 know about it.

Provision service have the following methods to address this:

* RegisterModelHandler(ModelHandlerBase modelHandlerType)
* RegisterModelHandlers(Assembly assembly)

Let's use the first one and register our handler:

[TEST.RegisterCustomModelHandler]

#### Custom syntax
There is a separate article on how to create a [custom syntax extensions](http://docs.subpointsolutions.com/spmeta2/extensibility/writing-custom-syntax/), so let's just improve our provision and add custom syntax for ChangeWebTitleAndDescriptionDefinition:

[CLASS.ChangeWebTitleAndDescriptionDefinitionSyntax]

Now we can re-write provision with a better syntax:

[TEST.RegisterCustomModelHandlerWithSyntax]

#### Handling events
We expect that our model handler would raise OnProvisioning / OnProvisioned while pushing definition to SharePoint. Let's attache to these events and see how it goes.

[TEST.RegisterCustomModelHandlerWithEvents]