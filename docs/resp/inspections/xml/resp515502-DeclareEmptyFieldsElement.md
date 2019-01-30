---
title: Declare empty Fields element
id: resp515502
---
## Description
Declare empty Fields element when using only ContentTypeRefs. Fields automatically populated from content types.

```xml
<List xmlns:ows="Microsoft SharePoint" title="List title" other="" attributes="">
    <Metadata>
        <ContentTypes>
            <ContentTypeRef id="0x0100EDFEDEA571A241FD80430F4D48A91346"></ContentTypeRef>
            <ContentTypeRef id="0x0120"></ContentTypeRef>
        </ContentTypes>
        <Fields>
        </Fields>
        <Views>
        </Views>
        <Forms>
        </Forms>
    </Metadata>
</List>
```

This works well. For most field types, that is. It does not work for Calculated Fields. More about <a title="this" href="http://www.hekstra.org/how-to-deploy-a-calculated-field/" target="_blank">this</a>.</pre>

## Resolution
Add empty Fields node to List shema.

## Links
- [Fields Element](http://msdn.microsoft.com/en-us/library/office/ms451470.aspx)
