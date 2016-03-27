---
Title: Unsafe cast on SPItemEventDataCollection.Item
FileName: resp510259.html
---
### Description
While using SPItemEventProperties the SPItemEventDataCollection.Item contains data for specified key. In case of key missing it returns null so null reference exceptions might be arised with ToString() call.

The following code is unsafe:
<a href="_samples/UnsafeCastingInItemReceiver-UnsafeCastOnSPItemEventDataCollectionItem.sample-ref"></a>

### Resolution
First check the result of SPItemEventDataCollection.Item access for null. Then cast it to required type.

### Links
- [SPItemEventDataCollection.Item property](https://msdn.microsoft.com/EN-US/library/microsoft.sharepoint.spitemeventdatacollection.item.aspx)
- [SPItemEventProperties.AfterProperties property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spitemeventproperties.afterproperties.aspx)