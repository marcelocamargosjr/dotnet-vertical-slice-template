namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Infrastructure.MessageBrokers;

public class MetaData
{
    public required string MessageId { get; set; }

    public required string MessageVersion { get; set; }

    public required string CorrelationId { get; set; }

    public DateTimeOffset? CreationDateTime { get; set; }

    public DateTimeOffset? EnqueuedDateTime { get; set; }
}