---
Title: Deploy lookup field correctly
FileName: resp515103.html
---
### Description
The following checks should be met:

- Remove attribute Version from field
- Add ShowField="Title" attribute to lookup field
- Set WebId="~sitecollection" or remove WebId attribute from lookup field
- Add List="{WebRelativeListUrl}" attribute to lookup field if List attribute is missing
- Change List attribute from GUID to ListUrl for lookup field if List attribute present
- Check list existing for lookup field. It should be in same feature

### Notes
- Rule does not check fields in the List Schema
- reSP validates #6 as [separate rule](/resp/inspections/resp515114)

### Resolution
Fix validation required conditions.

### Links
- [Provisioning SharePoint 2010 Managed Metadata fields](http://www.sharepointconfig.com/2011/03/the-complete-guide-to-provisioning-sharepoint-2010-managed-metadata-fields/)