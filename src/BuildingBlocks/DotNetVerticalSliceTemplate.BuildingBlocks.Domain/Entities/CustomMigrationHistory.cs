namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public class CustomMigrationHistory : Entity<Guid>
{
    public string MigrationName { get; set; } = string.Empty;
}