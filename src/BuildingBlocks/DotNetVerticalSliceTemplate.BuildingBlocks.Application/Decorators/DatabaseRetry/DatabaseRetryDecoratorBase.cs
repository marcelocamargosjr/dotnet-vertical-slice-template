namespace DotNetVerticalSliceTemplate.BuildingBlocks.Application.Decorators.DatabaseRetry;

public abstract class DatabaseRetryDecoratorBase
{
    protected DatabaseRetryAttribute DatabaseRetryOptions { get; set; }

    protected void WrapExecution(Action action)
    {
        var executedTimes = 0;

        while (true)
        {
            try
            {
                executedTimes++;
                action();
                return;
            }
            catch (Exception ex)
            {
                if (executedTimes >= DatabaseRetryOptions.RetryTimes || !IsDatabaseException(ex))
                {
                    throw;
                }
            }
        }
    }

    protected async Task WrapExecutionAsync(Func<Task> action)
    {
        var executedTimes = 0;

        while (true)
        {
            try
            {
                executedTimes++;
                await action();
                return;
            }
            catch (Exception ex)
            {
                if (executedTimes >= DatabaseRetryOptions.RetryTimes || !IsDatabaseException(ex))
                {
                    throw;
                }
            }
        }
    }

    private static bool IsDatabaseException(Exception exception)
    {
        var message = exception.InnerException?.Message;

        if (message == null)
        {
            return false;
        }

        return message.Contains("The connection is broken and recovery is not possible")
               || message.Contains("error occurred while establishing a connection");
    }
}