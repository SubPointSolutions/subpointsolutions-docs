---
Title: Missing SPUrlZone param in SPSite constructor
FileName: resp510238.html
---
### Description
The SharePoint object model always creates new SPSite objects with the zone set to Default, even if the code that’s creating the object is running under a SharePoint extended web application associated with a zone other than Default. 

<a href="_samples/SpecifySPZoneInSPSite-IncorrectSPUrlZoneParamUsage.sample-ref"></a>

The issue is that when you run this code, you will always get the Zone with the value “Default”—which is fine as long as you are running the code in the URL of a SharePoint web application which is in the “Default” zone. The problem is that even if you use the URL of a web application which is in the Internet Zone (or indeed, any other zone) the code will still return the Default zone.

### Resolution
You have to specify SPUrlZone while creating new instance of the SPSite via new SPSite(Guid, …) constructor. 
To know the zone of a request you can use the SPContext.Current.Site.Zone class. This returns an enum of SPUrlZone which represents wether its a Default zone, Intranet Zone, Internet Zone, Custom Zone or Extranet Zone.
<a href="_samples/SpecifySPZoneInSPSite-CorrectSPUrlZoneParamUsage.sample-ref"></a>

### Links
- [SPSite Constructor](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spsite.spsite(v=office.14).aspx)
- [Translating URLs using Alternate Access Mappings from code](http://blog.hompus.nl/2011/02/23/translating-urls-using-the-alternate-access-mappings/)