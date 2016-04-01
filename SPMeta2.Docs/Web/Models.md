<properties
	pageTitle="Models"
    pageName="models"
    parentPageId="spmeta2"
/>
SPMeta2 introduces a domain model providing set of definitions for most of the SharePoint artifacts.

Before you begin, make sure you are familiar with the following concepts:

* [SPMeta2  basics](http://docs.subpointsolutions.com/spmeta2/basics/)
* [SPMeta2 definitions](http://docs.subpointsolutions.com/spmeta2/definitions/)

### Domain model

SPMeta2 introduces a domain of c# POCO objects, then it maps every single POCO object on SharePoint artifacts.

<img src='http://g.gravizo.com/g? digraph G { rankdir="LR";"Web definition" -> "SPMeta2";"Field definition" -> "SPMeta2"; "Content type definition" -> "SPMeta2";  
   "List definition" -> "SPMeta2"; "List view definition" -> "SPMeta2";  
   "Web part page definition" -> "SPMeta2"; "Web part definition" -> "SPMeta2"; 
   "... other definitions ..." -> "SPMeta2";  "SPMeta2" -> SharePoint;  } '></img>

Once artifacts are defined, a **model** is used to group artifacts together and to indicate an entry point for the provision flow.
SPMeta2 has several types of models, but the most used are the following:

* Site model
* Web model

Here is a refined view on definitions grouping under the site and web models:

<img src='http://g.gravizo.com/g?
 digraph G {
   rankdir="LR";
   "SPMeta2" -> SharePoint;   
   "Site model" -> "SPMeta2";
   "Web model" -> "SPMeta2";
   "Field definition"  -> "Site model";  
   "Content type definition" -> "Site model";  
   "User Custom Action" -> "Site model";  
   "List definition" -> "Web model";  
   "List view definition" -> "Web model";  
   "Web partpage" -> "Web model"; }' ></img>

### Creating a new model
Depending on your scenarios, you might be interested to create either site or web model, setup definitions and then run the provision.
SPMeta2 has a helper class **SPMeta2Model** which provides the following methods:

* SPMeta2Model.NewFarmModel(..)
* SPMeta2Model.NewWebApplicationModel(..)
* SPMeta2Model.NewSiteModel(..)
* SPMeta2Model.NewWebModel(..)

Most of the time you would be using either NewSiteModel() or NewWebModel() methods to get a new model instance.
Here are a few patterns on how to setup initial provision flow:

#### Setting up a site model
[TEST.SettingUpSiteModels]

#### Setting up a web model
[TEST.SettingUpWebModels]

### Next steps
* [Site model](http://docs.subpointsolutions.com/spmeta2/models/sitemodel/)
* [Web model](http://docs.subpointsolutions.com/spmeta2/models/webmodel/)