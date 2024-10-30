namespace DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

public interface IHasKey<T>
{
    T Id { get; set; }
}