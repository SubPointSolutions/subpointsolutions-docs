---
Title: ConfigurationManager is used
FileName: resp510202.html
---

### Description
Avoid using System.Configuration.ConfigurationManager and System.Web.Configuration.WebConfigurationManager classes as well as store any configurations in the web.config files. It requires web.config changes which might affect farm stability, supportability, maintainability and migration.
The rule checks follow properties usage:

- AppSettings
- ConnectionStrings

### Resolution

Depending on the particular scenario, consider the following options to manage configuration:

- Simple List on the target SPWeb or root web
- Properties bags within SPWeb, SPSite, SPFarm
- Secure Store Service.

What’s the difference between the WebConfigurationManager and the ConfigurationManager?

- WebConfigurationManager is made specifically for ASP.NET applications.
- WebConfigurationManager provides additional methods to load configuration files applicable to Web applications.
- ConfigurationManager provides also methods to load configuration files applicable to “.exe” applications.

### Links
- [SharePoint patterns & practices SharePoint Guidance](https://spg.codeplex.com/)
- [SharePoint Secure Store Service](https://msdn.microsoft.com/en-us/library/ee557754(v=office.14).aspx)
- [Code Snippet: Get User Credentials Using the Default Secure Store Provider](https://msdn.microsoft.com/en-us/library/ff394459(v=office.14).aspx)