namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public abstract class Entity<TKey> : IHasKey<TKey>
{
    public TKey Id { get; set; } = default!;
}