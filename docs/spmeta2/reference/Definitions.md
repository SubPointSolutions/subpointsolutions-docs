---
id: "definitions"
title: "Definitions"
---

### SPMeta2 Definitions

Essentially, definitions are c# POCO objects provided by SPMeta2 library. 
SPMeta2 introduces a domain model providing set of definitions for most of the SharePoint artifacts.

Before you begin, make sure you are familiar with the following concepts:

* [Get started with SPMeta2](/spmeta2/getting-started)

### Domain model

SPMeta2 introduces a domain of c# POCO objects, then it maps every single POCO object on SharePoint artifacts.

```mermaid
graph LR;
    a1["CSharp POCO objects"] --> a2["SPMeta2"];
    a2 --> a3["SharePoint"];
```

We use the following name convention to map SharePoint objects to SPMeta2 definition:

* "SP" prefix gets removed
* "Definition" postfix gets added

For instance, here are a few definitions for most common SharePoint artifacts:

* SPWeb => WebDefinition
* SPField => FieldDefinition
* SPContentType => ContentTypeDefinition

We have different editions of SharePoint, we have a split up between 'foundation' and 'standard' definitions across SPMeta2 library. 

#### SharePoint Foundation definitions
SharePoint Foundation definitions could be found in SPMeta2.dll under the following namespaces:

* SPMeta2.Definitions.* - contains SharePoint Foundation definitions
* SPMeta2.Definitions.ContentTypes.* - contains definitions for content type operations
* SPMeta2.Definitions.Fields.* - contains typed field definitions
* SPMeta2.Definitions.Webparts.* - contains typed web part definitions

#### SharePoint Standard definitions
SharePoint standard definitions could be found in SPMeta2.Standard.dll under the following namespaces:

* SPMeta2.Standard.Definitions.* - contains SharePoint Standard definitions
* SPMeta2.Standard.Definitions.DisplayTemplates.* - contains various display template definitions
* SPMeta2.Standard.Definitions.Fields.* - contains typed field definitions
* SPMeta2.Standard.Definitions.Taxonomy.* - contains taxonomy related definitions
* SPMeta2.Standard.Definitions.Webparts.* - contains typed web part definitions