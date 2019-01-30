---
id: "modulefiledefinition"
title: "ModuleFileDefinition"
scenario_model: "Web model"
scenario_category: "Files"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Module files provision is enabled via ModuleFileDefinition object.

Should be deployed under a document library or content type. In case of content type, a resource folder is used.

Both CSOM/SSOM object models are supported. Provision checks if object exists looking up it by Name property, then creates a new object. You can deploy either single object or a set of the objects using AddModuleFile() extension method as per following examples.

## Examples

### Add module file to Style Library
```cs
var cssFile = new ModuleFileDefinition
{
    FileName = "m2-styles.css",
    Overwrite = true,
    Content = Encoding.UTF8.GetBytes(".m2-content { padding:10px; border:1px red solid; } ")
};
 
var jsFile = new ModuleFileDefinition
{
    FileName = "m2-app.js",
    Overwrite = true,
    Content = Encoding.UTF8.GetBytes(" alert('hello, m2!'); ")
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
    {
        list
            .AddModuleFile(cssFile)
            .AddModuleFile(jsFile);
    });
});
 
DeployModel(model);

```


### Add module file to folder
```cs
var cssFile = new ModuleFileDefinition
{
    FileName = "m2-red.css",
    Overwrite = true,
    Content = Encoding.UTF8.GetBytes(".m2-red { color:red; } ")
};
 
var jsFile = new ModuleFileDefinition
{
    FileName = "m2-logger-module.js",
    Overwrite = true,
    Content = Encoding.UTF8.GetBytes(" function(msg) { console.log(msg); } ")
};
 
var cssFolder = new FolderDefinition
{
    Name = "m2-css"
};
 
var jsFolder = new FolderDefinition
{
    Name = "m2-js"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
    {
        list
            .AddFolder(cssFolder, folder =>
            {
                folder.AddModuleFile(cssFile);
            })
            .AddFolder(jsFolder, folder =>
            {
                folder.AddModuleFile(jsFile);
            });
    });
});
 
DeployModel(model);
```