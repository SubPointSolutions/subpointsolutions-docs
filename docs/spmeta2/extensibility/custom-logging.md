---
id: "custom-logging"
title: "Custom logging"
---

Logging is an essential part of software development. 
It provides developers and support teams a deeper overview and enable them to see what is happening in the application. 

SPMeta2 has built-in logging to trace most of the critical operations related to provision. 
A high level abstraction for all logging operation is covered by TraceServiceBase class. TraceServiceBase class is an abstract one. It has a basic set of methods to report information, exception and warning as following:
* TraceServiceBase.Critical(int id, object message)
* TraceServiceBase.Error(int id, object message)
* TraceServiceBase.Warning(int id, object message)
* TraceServiceBase.Information(int id, object message)
* TraceServiceBase.Verbose(int id, object message)

All the codebase refers to logging subsustem as TraceServiceBase never knowing what is the actual implementation of the logging operations.
Obtaining a concrete implementation of the loggin service should be done as following:

Here is an example how a logging service instance can be obtained and used:

```cs
// get an instance of ServiceContainer
// then get an instance of required service such as TraceServiceBase
 
var traceService = ServiceContainer.Instance.GetService<TraceServiceBase>();
 
// use trace methods as usual
traceService.Verbose(0, "my verbose message");
```

SPMeta2 has a default implementation of TraceServiceBase which is TraceSourceService. We use default .NET logging based on Diagnostic.TraceSource. 
Default TraceSourceService class created a new instance of Diagnostic.TraceSource with the name 'SPMeta2'. It redirects all the logging to the trace listners defined in the app.config file for 'SPMeta2' name.

#### Replacing default logging
As SPMeta2 is used as a 3rd part library in your application, it may be necessary to integrate SPMeta2 logging output with your preferred logging. 
That integration can be accomplished in two steps:
* A custom logging service is to be written
* Default logging service needs to be replaced

Here is an example on a custom logging service implementation:

```cs
public class CustomLoggingService : TraceServiceBase
{
 
    public override void Critical(int id, object message, Exception exception)
    {
        // handle critical event the way you like
    }
 
    public override void Error(int id, object message, Exception exception)
    {
        // handle error the way you like
    }
 
    public override void Warning(int id, object message, Exception exception)
    {
        // handle warning the way you like
    }
 
    public override void Information(int id, object message, Exception exception)
    {
        // handle info the way you like
    }
 
    public override void Verbose(int id, object message, Exception exception)
    {
        // handle verbose the way you like
    }
 
    public override void TraceActivityStart(int id, object message)
    {
        // no implementation is required
    }
 
    public override void TraceActivityStop(int id, object message)
    {
        // no implementation is required
    }
 
    public override void TraceActivityTransfer(int id, object message, Guid relatedActivityId)
    {
        // no implementation is required
    }
 
    public override Guid CurrentActivityId
    {
        get { return Guid.Empty; }
        set
        {
 
        }
    }
}
```

Once a custom logging service is implemented, we still need to replace the default logging service with our custom one. That can be accomplished with the following code:

```cs
// get an instance of ServiceContainer
// override .Services collection with the right mapping
// typeof(TraceServiceBase) -> your instance of TraceServiceBase class
 
var serviceInstancies = ServiceContainer.Instance.Services[typeof(TraceServiceBase)];
 
serviceInstancies.Clear();
serviceInstancies.Add(new CustomLoggingService());
 
// provision models as usual
// from now on, all logging calls will go to CustomLoggingService instance
```

Once done, SPMeta2 will use custom logging service to push all trace messages.