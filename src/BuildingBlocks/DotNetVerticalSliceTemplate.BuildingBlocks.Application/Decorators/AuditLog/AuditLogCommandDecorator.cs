using System.Text.Json;
using DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Commands;

namespace DotNetVerticalSliceTemplate.BuildingBlocks.Application.Decorators.AuditLog;

[Mapping(Type = typeof(AuditLogAttribute))]
public class AuditLogCommandDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<TCommand> _handler;

    public AuditLogCommandDecorator(ICommandHandler<TCommand> handler)
    {
        _handler = handler;
    }

    public async Task HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        var commandJson = JsonSerializer.Serialize(command);
        Console.WriteLine($"Command of type {command.GetType().Name}: {commandJson}");
        await _handler.HandleAsync(command, cancellationToken);
    }
}