namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Infrastructure.MessageBrokers;

public interface IOutBoxEventPublisher
{
    static abstract string[] CanHandleEventTypes();

    static abstract string CanHandleEventSource();

    Task HandleAsync(PublishingOutBoxEvent outbox, CancellationToken cancellationToken = default);
}

public class PublishingOutBoxEvent
{
    public required string Id { get; set; }

    public required string EventType { get; set; }

    public required string EventSource { get; set; }

    public required string Payload { get; set; }
}