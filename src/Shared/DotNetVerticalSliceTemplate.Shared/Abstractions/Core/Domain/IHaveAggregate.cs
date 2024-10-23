using DotNetVerticalSliceTemplate.Shared.Abstractions.Core.Domain.Events;

namespace DotNetVerticalSliceTemplate.Shared.Abstractions.Core.Domain;

public interface IHaveAggregate : IHaveDomainEvents, IHaveAggregateVersion
{
}