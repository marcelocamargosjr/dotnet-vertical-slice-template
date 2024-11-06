using System.Reflection;
using DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Commands;
using DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Queries;
using DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Events;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common;

public class Dispatcher
{
    private readonly IServiceProvider _provider;

    private static readonly List<Type> EventHandlers = [];

    public static void RegisterEventHandlers(Assembly assembly, IServiceCollection services)
    {
        var types = assembly.GetTypes()
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)))
            .ToList();

        foreach (var type in types)
        {
            services.AddTransient(type);
        }

        EventHandlers.AddRange(types);
    }

    public Dispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        var type = typeof(ICommandHandler<>);
        Type[] typeArgs = [command.GetType()];
        var handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _provider.GetService(handlerType)!;
        await handler.HandleAsync((dynamic)command, cancellationToken);
    }

    public async Task<T> DispatchAsync<T>(IQuery<T> query, CancellationToken cancellationToken = default)
    {
        var type = typeof(IQueryHandler<,>);
        Type[] typeArgs = [query.GetType(), typeof(T)];
        var handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _provider.GetService(handlerType)!;
        Task<T> result = handler.HandleAsync((dynamic)query, cancellationToken);

        return await result;
    }

    public async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        foreach (var handlerType in EventHandlers)
        {
            var canHandleEvent = handlerType.GetInterfaces()
                .Any(x => x.IsGenericType
                          && x.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)
                          && x.GenericTypeArguments[0] == domainEvent.GetType());

            if (canHandleEvent)
            {
                dynamic handler = _provider.GetService(handlerType)!;
                await handler.HandleAsync((dynamic)domainEvent, cancellationToken);
            }
        }
    }
}