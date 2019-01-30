---
id: "folderdefinition"
title: "FolderDefinition"
scenario_model: "Web model"
scenario_category: "Folders"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Folders provision is enabled via FolderDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if folder exists looking up it by Name property, then creates a new folder. You can deploy either single folder or a set of the folder using AddFolder() extension method as per following examples. Folder nesting is supported as well.

## Examples

### Add folders

```cs
var activeDocsFolder = new FolderDefinition
{
    Name = "Active documents"
};
 
var archiveFolder = new FolderDefinition
{
    Name = "Archive"
};
 
var listWithFolders = new ListDefinition
{
    Title = "List with folders",
    Description = "Custom list with folders.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "ListWithFolders"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(listWithFolders, list =>
    {
        list
            .AddFolder(activeDocsFolder)
            .AddFolder(archiveFolder);
    });
});
 
DeployModel(model);
```

### Add folders to list

```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(DocLists.GeneralReports, list =>
    {
        list
            .AddFolder(DocFolders.Years.Year2013)
            .AddFolder(DocFolders.Years.Year2014)
            .AddFolder(DocFolders.Years.Year2015);
    });
});
 
DeployModel(model);
```

### Add folder hierarchy to list

```cs
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(DocLists.GeneralReports, list =>
    {
        list
            .AddFolder(DocFolders.Years.Year2013, year2013 =>
            {
                year2013
                    .AddFolder(DocFolders.Quarters.Q1)
                    .AddFolder(DocFolders.Quarters.Q2)
                    .AddFolder(DocFolders.Quarters.Q3)
                    .AddFolder(DocFolders.Quarters.Q4);
            })
            .AddFolder(DocFolders.Years.Year2014, year2014 =>
            {
                year2014
                    .AddFolder(DocFolders.Quarters.Q1)
                    .AddFolder(DocFolders.Quarters.Q2)
                    .AddFolder(DocFolders.Quarters.Q3)
                    .AddFolder(DocFolders.Quarters.Q4);
            })
            .AddFolder(DocFolders.Years.Year2015, year2015 =>
            {
                year2015
                    .AddFolder(DocFolders.Quarters.Q1)
                    .AddFolder(DocFolders.Quarters.Q2)
                    .AddFolder(DocFolders.Quarters.Q3)
                    .AddFolder(DocFolders.Quarters.Q4);
            });
    });
});
 
DeployModel(model);
```