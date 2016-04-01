---
Title: RunWithElevatedPrivileges is used while HTTPContext is null
FileName: resp510244.html
---

### Description
You do not have elevation of privilege when using SPSecurity.RunWithElevatedPrivileges in (1) Workflow, (2) Timer Job, (3) Feature Receiver or (4) Event handler (SPItemEventReceiver, SPListEventReceiver,SPWebEventReceiver, SPWorkflowEventReceiver) in the follow cases:

I. When HTTPContext (SPContext to be more specific) is null.

- SharePoint routinely runs your workflows under completely different processes. The result is you cannot use SPContext.Current (in workflow activities you have to use a WorkflowContext instance which provides a Web property).
- The SharePoint timer service is a windows service. So SPContext is not accessible and you should pass a site and web Ids(Urls) to the timer job and open new web.
- Because you can’t be sure where the FeatureReceiver is being called from (command line, timer service, web ui) you can’t use method of getting a SPSite/SPWeb object over SPContext (instead you can access the context through SPFeatureReceiverProperties.Feature.Parent).
- Asynchronous list item event handlers like ItemAdded do not have HTTPContext\SPContext context. Synchronous event handlers can’t also be initiated by a request in browser (for example: initiated from timer job)

II. When current thread is not using impersonation or current user is already App Pool account.

- Workflow runs under App Pool account (However, if this is a workflow created in SharePoint Designer then the default SPD Actions have their permissions trimmed to match those of the person who starts the workflow).
- Jobs are executed under SharePoint timer service account (OWSTimer process). RunWithElevatedPrivileges will have no effect.
- It is unclear which windows identity a feature event receiver will be running under as we don’t know if it will be called by STSADM (cmd.exe), “Windows Share Services Administration” timer service (WSSADMIN.EXE) or the WebUI (w3wp.exe with the app pools identity).
- Generally both synchronous and asynchronous event receivers are executed under current user account. In case of not user initiated, like timer job, see ch.2.

### Summary
You should avoid using SPSecurity.RunWithElevatedPrivileges for elevation of privilege. Instead :

- to impersonate SP objects use SPUserToken. Note: avoid passing SharePoint objects between different security contexts (SPSite instances). Example: An SPUser object created from one SPSite object cannot be passed reliably to another SPSite object.
- to impersonate network calls (DB access) in trusted environment when HTTPContext/SPContext is null use WIN 32 API or WindowsIdentity.Impersonate(token).

Examples of Trusted Connection (Windows Authentication):
[TEST.TrustedConnectionSample]

### FAQ
*When I can use SPSecurity.RunWithElevatedPrivileges?*

If you want to make a network calls, accesses network or file resources under the application pool identity then SPSecurity.RunWithElevatedPrivileges is the only choice. Note: dispose of all objects in the
delegate. Do not pass SharePoint objects out of the RunWithElevatedPrivileges method.

*Can I use WIN 32 API in web part or other user control to impersonate?*

No! SharePoint request must impersonate the calling user’s identity (<identity impersonate=”true” /> in web.config). SharePoint web applications are configured to impersonate the calling user automatically. If you try to suspend this impersonation by using WIN 32 API, your code may fail or behave abnormally.

### Links
- [Impersonation in SharePoint : An Extreme Overview](http://extreme-sharepoint.com/2012/05/30/impersonation-elevation-of-privileges)
- [Sample of impersonation not using RunWithElevatedPrivilages](http://www.sharepoint-tips.com/2007/03/sample-event-handler-to-set-permissions.html)
- [Impersonation in Event Handlers](http://www.sharepoint-tips.com/2007/03/impersonation-in-event-handlers.html)
- [Event handler impersonation – continued](http://www.sharepoint-tips.com/2007/03/event-handler-impersonation-continued.html)
- [SharePoint Feature Receivers – the hidden details](http://blog.pentalogic.net/2010/06/sharepoint-feature-receivers-events-details/)
