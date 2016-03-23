---
Title: gProcessingId parameter is missed for SPSite.AddWorkItem()
FileName: resp510257.html
---
### Description
Specify gProcessingId parameter for [SPSite.AddWorkItem()](http://msdn.microsoft.com/en-us/library/ms476803.aspx) as Guid.Empty. Overwise it fail.

### Resolution
Specify gProcessingId parameter for SPSite.AddWorkItem() as Guid.Empty.

### Links
- [Processing items with Work Item Timer Jobs in SharePoint 2010](http://blog.mastykarz.nl/processing-items-work-item-timer-jobs-sharepoint-2010/)
- [All about SharePoint Work Item Timer Jobs](http://www.ericgregorich.com/blog/2014/1/25/using-work-item-timer-jobs-in-sharepoint)
- [SPWorkItemJobDefinition – a different kind of SharePoint Timer Job](http://sharepintblog.com/2011/12/12/spworkitemjobdefinition-a-different-kind-of-sharepoint-timer-job/)
- [Creating a Lightweight Timer Job for a Site Collection: Defining Custom Work Items](http://www.boostsolutions.com/blog/creating-a-lightweight-timer-job-for-a-site-collection-defining-custom-work-items/)