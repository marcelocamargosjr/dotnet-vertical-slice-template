namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public class ConfigurationEntry : Entity<Guid>
{
    public required string Key { get; set; }

    public required string Value { get; set; }
}