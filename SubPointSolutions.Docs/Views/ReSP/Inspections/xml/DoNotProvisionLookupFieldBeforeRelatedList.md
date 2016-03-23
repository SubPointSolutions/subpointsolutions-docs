---
Title: Incorrect lookup field provision
FileName: resp515114.html
---
### Description
In SharePoint development, developers are often stymied be seemingly simple tasks. Provisioning a lookup field using the declarative model in a solution package is one such task. The most common symptom of an improperly-provisioned lookup is that no error will occur on deployment, but the lookup field will have an empty reference to its parent list when viewed in List Settings. Developers will usually, and correctly, assume that the field is broken because the parent list did not exist yet when the field is provisioned. The most common way this is to use a Feature Receiver to provision their lookups after declaratively provisioning everything else because they cannot figure out a way to make the declarative approach work.

The trick to doing this right is understanding that the order in which the package deploys the artifacts is important. Look at the image below, which shows a fairly representative simple data model for a SharePoint solution. The screen shot is from VS2102/SP2013, but it works exactly the same in 2010.

<img class="alignnone" src="http://derekgusoff.files.wordpress.com/2013/04/package.jpg" alt="" width="434" height="468" />

It shows fields, content types, and lists, deployed in that order. Now, the Projects list has a lookup to the Clients list. If you put that lookup in the SiteColumns element, it will fail, because it will have been provisioned in the wrong order. The same for different features. The practice to make this work is to put the Field element for the lookup directly under the ListInstance element it depends on (or into the same feature). By doing this there is no possibility the lookup will be provisioned out of order, because SharePoint will deploy the stuff in an individual elements file in the order it appears in the file:

<img class="alignnone" src="http://derekgusoff.files.wordpress.com/2013/04/elements.jpg" alt="" width="527" height="354" />


### Resolution
Consider to put lookup fields in the same feature along with related lists.

### Links
- [Field Element](http://msdn.microsoft.com/en-us/library/office/aa979575.aspx)
- [How logic flaws in SharePoint's Element activation process can break Lookup fields](http://www.codefornuts.com/2010/12/how-logic-flaws-in-sharepoints-element.html)
- [Add SharePoint lookup column declaratively through CAML XML](http://blogs.msdn.com/b/joshuag/archive/2008/03/14/add-sharepoint-lookup-column-declaratively-through-caml-xml.aspx)