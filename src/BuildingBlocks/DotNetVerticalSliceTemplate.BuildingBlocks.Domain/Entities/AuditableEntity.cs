using System.ComponentModel.DataAnnotations;

namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public abstract class AuditableEntity<TKey> : IHasKey<TKey>, ITrackable
{
    public TKey Id { get; set; } = default!;

    [Timestamp]
    public byte[] RowVersion { get; set; } = default!;

    public string CreatedBy { get; set; } = string.Empty;

    public DateTimeOffset CreatedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }
}