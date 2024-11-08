using System.ComponentModel.DataAnnotations;

namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public abstract class AuditableEntity<TKey> : Entity<TKey>, ITrackable
{
    [Timestamp]
    public required byte[] RowVersion { get; set; }

    public required string CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }
}