using Connected.Entities;
using Connected.Resources.Types.JobPositions;
using Connected.Resources.Types.JobPositions.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.JobPositions.Ops;

internal sealed class Query(IJobPositionCache cache)
    : ServiceFunction<IQueryJobPositionDto, IImmutableList<IJobPosition>>
{
    protected override async Task<IImmutableList<IJobPosition>> OnInvoke()
    {
        var queryable = cache.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Dto.Code))
            queryable = queryable.Where(f => string.Equals(f.Code, Dto.Code, StringComparison.OrdinalIgnoreCase));

        return await queryable.AsEntities();
    }
}
