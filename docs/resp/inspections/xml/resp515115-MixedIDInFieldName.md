---
title: Avoid mixed 'ID' and 'Id' names
id: resp515115
---
## Description
It might be suggested to avoid mixing up “ID” and “Id” while crafting field:

Here is a potentally confusing usage of upper-case and lower-case "ID" token:
- customerID
- clientId
- documentID

It could be confusing for other people while working with read-write operation on fields, content types and list items.
Besides, it might lead to unplesant typo issues.

```xml
<Field id="{FE2C05A9-1861-48C3-8DB4-3C08E9830E2C}" type="Text" name="customerID" staticname="customerID" overwrite="TRUE">
</Field>
 
<Field id="{FE2C05A9-1861-48C3-8DB4-3C08E9830E2C}" type="Text" name="clientId" staticname="clientId" overwrite="TRUE">
</Field>
 
<Field id="{FE2C05A9-1861-48C3-8DB4-3C08E9830E2C}" type="Text" name="documentID" staticname="documentID" overwrite="TRUE">
</Field>
```

## Resolution
Tend to use either "ID" or "Id" token for all cases.

## Links
Not provided.
