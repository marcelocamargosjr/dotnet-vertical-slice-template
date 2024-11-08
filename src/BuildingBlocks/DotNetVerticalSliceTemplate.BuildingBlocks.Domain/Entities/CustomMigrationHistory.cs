namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public class CustomMigrationHistory : Entity<Guid>
{
    public required string MigrationName { get; set; }
}