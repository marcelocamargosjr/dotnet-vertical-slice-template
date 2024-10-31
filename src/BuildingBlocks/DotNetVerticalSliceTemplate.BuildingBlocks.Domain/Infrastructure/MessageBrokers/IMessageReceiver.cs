namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Infrastructure.MessageBrokers;

public interface IMessageReceiver<TConsumer, out T>
{
    Task ReceiveAsync(Func<T, MetaData, Task> action, CancellationToken cancellationToken = default);
}