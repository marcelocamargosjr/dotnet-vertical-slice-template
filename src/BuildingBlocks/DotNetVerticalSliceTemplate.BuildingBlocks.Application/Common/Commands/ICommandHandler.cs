﻿namespace DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Commands;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}