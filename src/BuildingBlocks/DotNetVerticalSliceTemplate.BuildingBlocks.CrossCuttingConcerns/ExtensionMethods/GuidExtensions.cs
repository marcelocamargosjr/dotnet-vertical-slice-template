namespace DotNetVerticalSliceTemplate.BuildingBlocks.CrossCuttingConcerns.ExtensionMethods;

public static class GuidExtensions
{
    public static bool IsNullOrEmpty(this Guid? guid)
    {
        return guid == null || guid == Guid.Empty;
    }
}