namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public class ConfigurationEntry : Entity<Guid>
{
    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}