---
title: General exception is suppressed
id: resp510236
---

## Description
The exception itself should not be ignored because it can be affected to regular program flow. There are three exception types (logical groups):

- **Usage exceptions**. Means you try to use method with wrong parameters. Validate method parameter at first and throw such exception BEFORE main code. Never catch or handle it.
- **System exceptions**. Raised when something abnormal happened inside the method main code and not related from caller. Generally it is required to re-throw exception up. Catch it only:
it is possible to compensate results, make a workaround actions;
on the application top level to avoid user from stress from exception technical detals;
to wrap original exception into custom exception type.
-  **Application exceptions** like NullReferenceException, InvalidOperation etc. These are about logic problem in code. You can handle its with the same reasons as for system exceptions.

```cs
try
{
    CalledMethod("Test");
}
// DO NOT CATCH USAGE EXCEPTION
catch (ArgumentNotSpecifiedException ex)
{
    // special handling for ArgumentNotSpecifiedException
}
catch (Exception ex)
{
    // log it
    throw new WrappedException("Method XXX call  error occurred", ex); // wrapped & chained exceptions.
}
finally
{
    // normal clean goes here (like closing open files).
}
```


```cs
// Validate parameter and throw "usage exception"
if (String.IsNullOrEmpty(p1))
    throw new ArgumentNotSpecifiedException("Parameter p1 must be specified");
 
// Here we save data to the storage and the "system exception" could be raised
try
{
    DAL.Save(p1);
}
catch (SqlException e)
{
    if (e.ErrorCode != NO_ROW_ERROR)
    {
        // filter out NoDataFound.
        // do special cleanup, like maybe closing the "dirty" database connection.
        // throw e; <- DO NOT DO IT. This destroys the strack trace information!
        throw; // this preserves the stack trace
    }
}
```

In case of logging handle exception with re-throw. It will allow to take a decision on the upper level.

## Resolution
- If method has a [side-effect](http://en.wikipedia.org/wiki/Side_effect_%28computer_science%29) it is strongly recommended to avoid ANY exception suppressions, not only specific type.
- Specify exception type in the catch clause. Mostly it could be SPException.
- Rethrow exception in catch(Exception) block using throw or catch specific exception.

## Links
- [Design Guidelines for Exceptions](https://msdn.microsoft.com/en-us/library/ms229014.aspx)
- [The Pragmatic Programmer](http://en.wikipedia.org/wiki/The_Pragmatic_Programmer)
- [Clean Code: A Handbook of Agile Software Craftsmanship](http://books.google.ru/books/about/Clean_Code.html?id=_i6bDeoCQzsC&redir_esc=y)
- [SPException class](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spexception.aspx)
