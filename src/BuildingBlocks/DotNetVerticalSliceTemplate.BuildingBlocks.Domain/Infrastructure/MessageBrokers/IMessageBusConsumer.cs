namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Infrastructure.MessageBrokers;

public interface IMessageBusConsumer<TConsumer, in T>
{
    Task HandleAsync(T data, MetaData metaData, CancellationToken cancellationToken = default);
}