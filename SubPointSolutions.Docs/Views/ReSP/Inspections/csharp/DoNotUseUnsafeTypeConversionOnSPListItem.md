---
Title: Unsafe cast on SPListItem
FileName: resp510213.html
---
### Description
SPListItem is untyped entity, so null reference exceptions on nullable types or wrong type conversion exception might arise.

Incorrect usage:
<a href="_samples/DoNotUseUnsafeTypeConversionOnSPListItem-IncorrectSPListItemCast.sample-ref"></a>

### Resolution
Consider Convert.ToXXX method or manual conversion to handle wrong/nullable types.
<a href="_samples/DoNotUseUnsafeTypeConversionOnSPListItem-CorrectSPListItemCast.sample-ref"></a>

### Links
- [Convert Methods](https://msdn.microsoft.com/en-us/library/system.convert_methods(v=vs.110).aspx)
