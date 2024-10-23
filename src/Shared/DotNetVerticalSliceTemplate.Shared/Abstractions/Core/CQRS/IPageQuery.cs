using DotNetVerticalSliceTemplate.Shared.Abstractions.Core.Paging;

namespace DotNetVerticalSliceTemplate.Shared.Abstractions.Core.CQRS;

public interface IPageQuery<out TResponse> : IPageRequest, IQuery<TResponse>
    where TResponse : class;