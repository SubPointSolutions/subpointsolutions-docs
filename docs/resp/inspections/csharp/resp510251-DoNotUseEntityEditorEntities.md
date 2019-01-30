---
title: EntityEditor.Entities is used
id: resp510251
---

## Description
It is not recommended to use the Entities property to get the selected entities, because using this sometimes causes unexpected behavior.

## Resolution
It's much more reliable to use ResolvedEntities instead.

```cs
SPPrincipalInfo result = null;
 
foreach (Control control in controlCollection)
{
    var peopleEditor = control as PeopleEditor;
    if (peopleEditor != null && peopleEditor.Entities.Count == 1)
    {
        PickerEntity pickerEntity = (PickerEntity)peopleEditor.Entities[0];
        // get principal info code here ...
        return result;
    }
    if (control.HasControls())
    {
        result = GetPeoplePickerUser(control.Controls);
    }
}
 
return result;
```

## Links
- [EntityEditor.Entities property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.entityeditor.entities.aspx)
- [EntityEditor.ResolvedEntities property](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.webcontrols.entityeditor.resolvedentities.aspx)
