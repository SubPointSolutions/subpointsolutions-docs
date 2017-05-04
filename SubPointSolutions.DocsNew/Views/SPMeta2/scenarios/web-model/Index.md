----
SampleCategory: Web Model
Title: Overview
Order: 600
Category: Web Model
TileLink: true
TileLinkOrder: 40
----

Something about web model
```cs

var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(list =>
    {

    });
});
```