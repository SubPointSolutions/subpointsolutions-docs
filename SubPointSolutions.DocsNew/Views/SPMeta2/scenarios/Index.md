----
SampleCategory: Farm Model
LeftNavigationNode: true
TopNavigationNode: true
Subfolders: 
    - general-api
    - farm-and-webapplication-model
    - sitecollection-model
    - web-model
Title: Overview of API
Category: General API
CategoryOrder: 10
Order: 400
TileLink: true
TileLinkOrder: 40
----

Something about farm models:
```cs

var model = SPMeta2Model.NewFarmModel(farm =>
{
    web.AddFarmSolution(solution =>
    {

    });
});
```