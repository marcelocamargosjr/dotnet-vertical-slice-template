namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public interface ITrackable
{
    byte[] RowVersion { get; set; }

    string CreatedBy { get; set; }

    DateTimeOffset CreatedAt { get; set; }

    string? ModifiedBy { get; set; }

    DateTimeOffset? ModifiedAt { get; set; }
}