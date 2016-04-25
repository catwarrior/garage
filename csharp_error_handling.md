# centrolize exception handling. 
## The class 
``` csharp
public class ErrorHanding
    {
        public static bool Try(Action tryAction, ILog log = null, Action catchAction = null, Action finallyAction = null)
        {
            if (tryAction == null)
                return false;
            try
            {
                tryAction.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                LogException(ex, log);
                Try(catchAction, log);
                return false;
            }
            finally
            {
                Try(finallyAction, log);
            }
        }

        private static void LogException(Exception ex, ILog log)
        {
            if (log != null)
                log.Debug(ex);
        }
    }
```

## Usage
``` csharp
   ErrorHanding
    .Try(tryAction: () =>
    {
         // put the try block here
    }, catchAction: () =>
    {
        // the catch
    }, finallyAction: () =>
    {
        // the finally
    }, log: log);
```

