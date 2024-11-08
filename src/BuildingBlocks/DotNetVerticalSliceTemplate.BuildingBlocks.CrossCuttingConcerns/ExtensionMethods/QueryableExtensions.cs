namespace DotNetVerticalSliceTemplate.BuildingBlocks.CrossCuttingConcerns.ExtensionMethods;

public static class QueryableExtensions
{
    public static IQueryable<T> Paged<T>(this IQueryable<T> source, int page, int pageSize)
    {
        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }
}