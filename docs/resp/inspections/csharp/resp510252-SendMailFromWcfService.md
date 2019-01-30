---
title: SPUtility.SendEmail usage while SPContext is null
id: resp510252
---
## Description
Sending an e-mail from a WCF service when SPContext is not available could fail. As a workaround, you have to prevent the mail function from reading the current context by using HttpContext.Current = null. If it can’t, it will retrieve the right context and it will then work.

## Resolution
```cs
// save current context
HttpContext curCtx = HttpContext.Current;
HttpContext.Current = null; // <-- recommended approach for wcf services
 
bool success = SPUtility.SendEmail(web, true, true, to, subject, body);
 
// restore the context
HttpContext.Current = curCtx;
```

The current context is set to null to force the context to be retrieved again. Saving the current context ensures that the service works properly after the method has been executed. 

**Note**: ASMX Web Services require the same procedure.

## Links
- [SharePoint 2010 - When Hosting Custom WCF Services in SharePoint, SPContext is Null due to MultipleBaseAddressBasicHttpBindingServiceHostFactory Bug](http://ddkonline.blogspot.ru/2012/02/sharepoint-2010-when-hosting-wcf.html)
- [SPUtility.SendEmail method](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.utilities.sputility.sendemail.aspx)
