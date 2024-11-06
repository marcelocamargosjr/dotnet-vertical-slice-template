using System.Reflection;
using DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Commands;
using DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Queries;
using DotNetVerticalSliceTemplate.BuildingBlocks.CrossCuttingConcerns.ExtensionMethods;

namespace DotNetVerticalSliceTemplate.BuildingBlocks.Application.Decorators;

internal static class Mappings
{
    static Mappings()
    {
        var decorators = Assembly.GetExecutingAssembly().GetTypes();
        foreach (var type in decorators)
        {
            if (type.HasInterface(typeof(ICommandHandler<>)))
            {
                var decoratorAttribute = (MappingAttribute)type.GetCustomAttributes(false).FirstOrDefault(x => x.GetType() == typeof(MappingAttribute));

                if (decoratorAttribute != null)
                {
                    AttributeToCommandHandler[decoratorAttribute.Type] = type;
                }
            }
            else if (type.HasInterface(typeof(IQueryHandler<,>)))
            {
                var decoratorAttribute = (MappingAttribute)type.GetCustomAttributes(false).FirstOrDefault(x => x.GetType() == typeof(MappingAttribute));

                if (decoratorAttribute != null)
                {
                    AttributeToQueryHandler[decoratorAttribute.Type] = type;
                }
            }
        }
    }

    public static readonly Dictionary<Type, Type> AttributeToCommandHandler = new();

    public static readonly Dictionary<Type, Type> AttributeToQueryHandler = new();
}

[AttributeUsage(AttributeTargets.Class)]
public sealed class MappingAttribute : Attribute
{
    public required Type Type { get; set; }
}