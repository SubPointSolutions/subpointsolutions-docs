---
title: Avoid comments for content types
id: resp515205
---
## Description
Xml comment in elements file can break your content type.
The following content type is incorrect and all fields after the comment won't be created by SharePoint.


```xml
<ContentType id="0x010100..." name="MyContentType" group="Project 1" description="Groovy" inherits="TRUE" version="0">
 <FieldRefs>
   <FieldRef id="{99F38C7E-0493-4beb-B1AE-2E2396B78BA2}" name="NiceNewField"></FieldRef>
   <!-- Needed to make the XXZ Widget work and this comment will break the content type! -->
   <FieldRef id="{F55C4D88-1F2E-4ad9-AAA8-819AF4EE7EE8}" name="PublishingPageContent"></FieldRef>
   <FieldRef id="{D6E31868-E402-4c28-BCDD-F8C517A7897B}" name="CommentingEnabled"></FieldRef>
   <FieldRef id="{1B14D023-939E-497e-9621-21CA3FDE7DDD}" name="RatingEnabled"></FieldRef>
   <FieldRef id="{EBDF37A6-5DA2-48a2-9493-FCFEDD40598E}" name="TaggingEnabled"></FieldRef>
   <FieldRef id="{D33453AC-5B1B-4A04-9673-CFBA8368195D}" name="Keywords"></FieldRef>
   <FieldRef id="{A45C395D-BBBF-47D8-9A46-3A3E070EB535}" name="KeywordsTaxHTField0" hidden="TRUE"></FieldRef>
 </FieldRefs>
</ContentType>
```

## Resolution
Remove all comments from content type schema.
The following content type is correct. Just remove comments from XML.

```xml
<ContentType id="0x010100..." name="MyContentType" group="Project 1" description="Groovy" inherits="TRUE" version="0">
 <FieldRefs>
   <FieldRef id="{99F38C7E-0493-4beb-B1AE-2E2396B78BA2}" name="NiceNewField"></FieldRef>
   <FieldRef id="{F55C4D88-1F2E-4ad9-AAA8-819AF4EE7EE8}" name="PublishingPageContent"></FieldRef>
   <FieldRef id="{D6E31868-E402-4c28-BCDD-F8C517A7897B}" name="CommentingEnabled"></FieldRef>
   <FieldRef id="{1B14D023-939E-497e-9621-21CA3FDE7DDD}" name="RatingEnabled"></FieldRef>
   <FieldRef id="{EBDF37A6-5DA2-48a2-9493-FCFEDD40598E}" name="TaggingEnabled"></FieldRef>
   <FieldRef id="{D33453AC-5B1B-4A04-9673-CFBA8368195D}" name="Keywords"></FieldRef>
   <FieldRef id="{A45C395D-BBBF-47D8-9A46-3A3E070EB535}" name="KeywordsTaxHTField0" hidden="TRUE"></FieldRef>
 </FieldRefs>
</ContentType>
```

## Links
- [Content Type Element](http://msdn.microsoft.com/en-us/library/office/aa544268(v=office.14).aspx)
- [Xml Comment in Elements File can Break your Content Type](https://www.1stquad.com/sharepoint-kompetenz-erfahrung-know-how/blog/default/oktober-2012/xml-comment-in-elements-breaks-your-ContentType)
