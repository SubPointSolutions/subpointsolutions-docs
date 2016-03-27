---
Title: Avoid mixed 'ID' and 'Id' names
FileName: resp515115.html
---
### Description
It might be suggested to avoid mixing up “ID” and “Id” while crafting field:

Here is a potentally confusing usage of upper-case and lower-case "ID" token:
- customerID
- clientId
- documentID

It could be confusing for other people while working with read-write operation on fields, content types and list items.
Besides, it might lead to unplesant typo issues.

<a href="_samples/MixedIDInFieldName-IncorrectSample.sample-ref"></a>

### Resolution
Tend to use either "ID" or "Id" token for all cases.

### Links
Not provided.