using DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Commands;
using DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Queries;

namespace DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common;

internal static class Utils
{
    public static bool IsHandlerInterface(Type type)
    {
        if (!type.IsGenericType)
        {
            return false;
        }

        var typeDefinition = type.GetGenericTypeDefinition();

        return typeDefinition == typeof(ICommandHandler<>)
               || typeDefinition == typeof(IQueryHandler<,>);
    }
}