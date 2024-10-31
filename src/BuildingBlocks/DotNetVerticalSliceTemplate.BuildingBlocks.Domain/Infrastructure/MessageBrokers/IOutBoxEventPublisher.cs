namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Infrastructure.MessageBrokers;

public interface IOutBoxEventPublisher
{
    static abstract string[] CanHandleEventTypes();

    static abstract string CanHandleEventSource();

    Task HandleAsync(PublishingOutBoxEvent outbox, CancellationToken cancellationToken = default);
}

public class PublishingOutBoxEvent
{
    public string Id { get; set; } = string.Empty;

    public string EventType { get; set; } = string.Empty;

    public string EventSource { get; set; } = string.Empty;

    public string Payload { get; set; } = string.Empty;
}