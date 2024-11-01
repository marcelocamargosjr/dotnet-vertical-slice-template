﻿using DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Services;
using DotNetVerticalSliceTemplate.BuildingBlocks.Domain.Entities;

namespace DotNetVerticalSliceTemplate.BuildingBlocks.Application.Common.Commands;

public class DeleteEntityCommand<TEntity> : ICommand
    where TEntity : Entity<Guid>, IAggregateRoot
{
    public TEntity Entity { get; set; } = default!;
}

internal class DeleteEntityCommandHandler<TEntity> : ICommandHandler<DeleteEntityCommand<TEntity>>
    where TEntity : Entity<Guid>, IAggregateRoot
{
    private readonly ICrudService<TEntity> _crudService;

    public DeleteEntityCommandHandler(ICrudService<TEntity> crudService)
    {
        _crudService = crudService;
    }

    public async Task HandleAsync(DeleteEntityCommand<TEntity> command, CancellationToken cancellationToken = default)
    {
        await _crudService.DeleteAsync(command.Entity, cancellationToken);
    }
}