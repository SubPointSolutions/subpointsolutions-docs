---
Title: Avoid jQuery(document).ready in master page
FileName: resp517303.html
---
### Description
Due specific SharePoint client side initialization life cycle, it is recommended to avoid using $(document).readyand windows.load = function() { …};.

It is a common practice to modify content from JavaScript. The end user can’t identify the moment when page has been changed, it looks like all page content rendered on server side. For example, SharePoint list views are used same approach named CSR.

$(document).ready used due to two reasons:

* run code AFTER DOM constructed
* run code BEFORE page rendered

Many times $(document).ready fires later than expected. Actually it handles DOMContentLoaded event. In case of static HTML content, DOMContentLoaded is raised right after content loaded from server(!) and before rendered. But SharePoint pages use JavaScript to build markup, offen when content is not loaded yet, thus it is unclear when the DOMContentLoaded event fires.

### Resolution
We recommend to keep follow three rules:

* Use [SP.SOD.executeOrDelayUntilScriptLoaded](http://msdn.microsoft.com/en-us/library/office/ff411788(v=office.14).aspx) to manage scripts load order NOT depending on sharepoint .js file
* Use [SP.SOD.execute](http://msdn.microsoft.com/en-us/library/office/ff407807(v=office.14).aspx) to manage scripts load order depending on sharepoint .js file
* Use arrays _spBodyOnLoadFunctionNames (sp2010) or _spBodyOnLoadFunctions (sp2013) to solve simple tasks on the SharePoint pages like list forms, views or web part pages. Be aware that content is often added after the page is loaded, for example: Web Parts in MDS, option tags in lookup fields, cascading lookups. Be sure you work with ready-to-proceed elements.
* In case of Minimal Download Strategy (MDS) use RegisterModuleInit function call to get your script loaded while asyc load occur.

<a href="_samples/AvoidJQueryDocumentReady-AvoidJQueryDocumentReadyInControl_Init.sample-ref"></a>


How about mQuery?
<a href="_samples/AvoidJQueryDocumentReady-AvoidJQueryDocumentReadyInControl_mQuery.sample-ref"></a>

In general mQuery does not play significant role and can’t be consider as common solution. It uses onDemandload mode on many pages. That means it have to be used as per following sample:

<a href="_samples/AvoidJQueryDocumentReady-AvoidJQueryDocumentReadyInMasterPage_mQuerySODExecute.sample-ref"></a>

and expected running time will be too late … defenitelly after content load/render.

### Links
- [SharePoint 2010 and the Chrome JavaScript Bug](http://mosswell.blogspot.co.uk/2013/06/sharepoint-2010-and-chrome-javascript.html)
- [Getting started with mQuery/m$ in SharePoint 2013 and SharePoint Online](http://spdevlab.com/2013/07/01/getting-started-with-mquerym-in-sharepoint-2013-and-sharepoint-online)
- [Custom JavaScript function loaded after the UI has been loaded (onLoad) in SharePoint 2013](http://josharepoint.com/2015/06/16/custom-javascript-function-loaded-after-the-ui-has-loaded-in-sharepoint-2013/)