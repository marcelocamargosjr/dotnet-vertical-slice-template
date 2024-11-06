namespace DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.DTOs;

public class Paged<T>
{
    public long TotalItems { get; set; }

    public required List<T> Items { get; set; }
}