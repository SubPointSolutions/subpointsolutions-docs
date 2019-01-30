---
id: "webpartdefinition"
title: "WebPartDefinition"
scenario_model: "Web model"
scenario_category: "Web Parts"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes

There are a few things around web part provision within SPMeta2 library:

* **ID** is used as a key for SSOM provision
* **Title** is used as a key for CSOM provision
* CSOM provision always deleted a web part and adds a new one

SPMeta2 provides three ways to provision a new web part. 
You use one of the following properties to define the provisino strategy:

* WebpartType prop (SSOM only) - provising AssemblyQualifiedName of the web part
* WebpartXmlTemplate prop - providing web part XML 
* WebpartFileName prop - providing file name from the web part gallery

**WebpartType** can be used only with SSOM. SPMeta2 would use the reflection to create an instance of the web part and either add or update it later.

**WebpartXmlTemplate** is supported by CSOM/SSOM. You need to provide XML template if the web part. Use either Sharepoint Designer to get one, or use web part export on the SharePoint page.

**WebpartFileName** needs to be a web part file name in the web part gallery. SPMeta2 would read this file, use this XML template and then push the web part on the page.

**ZoneId** and **ZoneIndex** are used to put the web part on the right place in the target page. That works well for web part pages along with publishing pages.

**AddToPageContent** flag is used to indicate that the web part needs to be added to the 'Content' are of the wiki/publishing page. Check more details on embedding web parts into wiki pages in the samples below.

Notice that WebPartDefinition provides a basic provision for generic web part. A much better provision could be archived either by using OnProvisioned events or "typed" web part definitions such as ContentEditorWebPartDefinition, ScriptEditorWebPartDefinition and the rest.
## Examples

### Add web part by type

```cs
// this would deploy a web part using WebpartType prop
// you need to provide AssemblyQualifiedName of the target web part type
// SPMeta2 would use reflection to create an instane of the web part in the runtime
// that works only for SSOM, not CSOM support yet
 
var contentEditorWebPart = new WebPartDefinition
{
    Title = "About SharePoint SSOM",
    Id = "m2AboutSharePointSSOM",
    WebpartType = typeof(ContentEditorWebPart).AssemblyQualifiedName,
    ZoneIndex = 10,
    ZoneId = "Main"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 webparts provision",
    FileName = "web-parts-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list.AddWebPartPage(webPartPage, page =>
        {
            page.AddWebPart(contentEditorWebPart);
        });
    });
});
 
DeploySSOMModel(model);

```


### Add web part by XML

```cs
// this whould deploy the web part using WebpartXmlTemplate prop
// you need to provide an XML template which you get from SharePoint
// export the wenb part, and put it into WebpartXmlTemplate prop
 
// here is a web part XML template
// usually, you export that XML from SharePoint page, but SPMeta2 has pre-build class
var contentEditorWebPartXml = BuiltInWebPartTemplates.ContentEditorWebPart;
 
var contentEditorWebPart = new WebPartDefinition
{
    Title = "About SharePoint XML",
    Id = "m2AboutSharePointXML",
    WebpartXmlTemplate = contentEditorWebPartXml,
    ZoneIndex = 20,
    ZoneId = "Main"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 webparts provision",
    FileName = "web-parts-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list.AddWebPartPage(webPartPage, page =>
        {
            page.AddWebPart(contentEditorWebPart);
        });
    });
});
 
DeployModel(model);

```

### Add web part from Gallery File

```cs
// this would deploy the web part using WebpartFileName
// you need to provide a file name ofthe web part template in the web part gallery
// SPMeta2 would load this file, then use an XML as a web part template
 
var contentEditorWebPart = new WebPartDefinition
{
    Title = "About SharePoint web part gallery",
    Id = "m2AboutSharePointWebPartGallery",
    // shortcut to "MSContentEditor.dwp",
    WebpartFileName = BuiltInWebpartFileNames.MSContentEditor,
    ZoneIndex = 20,
    ZoneId = "Main"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 webparts provision",
    FileName = "web-parts-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list.AddWebPartPage(webPartPage, page =>
        {
            page.AddWebPart(contentEditorWebPart);
        });
    });
});
 
DeployModel(model);

```

### Add web part with pre-configured XML

```cs
// this shows how to use SPMeta2 API to pre-process web part XML
 
// here is a web part XML template
// usually, you export that XML from SharePoint page, but SPMeta2 has pre-build class
var contentEditorWebPartXml = BuiltInWebPartTemplates.ContentEditorWebPart;
 
// let' set new some properties, shall we?
// we load XML by WebpartXmlExtensions.LoadWebpartXmlDocument() method
// it works well web both V2/V3 web part XML
// then change properties and seehow it goes
// then call ToString() to get string out of XML
var wpXml = WebpartXmlExtensions
               .LoadWebpartXmlDocument(contentEditorWebPartXml)
               .SetOrUpdateProperty("FrameType", "Standard")
               .SetOrUpdateProperty("Width", "500")
               .SetOrUpdateProperty("Heigth", "200")
               .SetOrUpdateContentEditorWebPartProperty("Content", "This is a new content!", true)
               .ToString();
 
var contentEditorWebPart = new WebPartDefinition
{
    Title = "New content",
    Id = "m2AboutSharePointnewContent",
    WebpartXmlTemplate = wpXml,
    ZoneIndex = 20,
    ZoneId = "Main"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 webparts provision",
    FileName = "web-parts-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.SitePages, list =>
    {
        list.AddWebPartPage(webPartPage, page =>
        {
            page.AddWebPart(contentEditorWebPart);
        });
    });
});
 
DeployCSOMModel(model);
```