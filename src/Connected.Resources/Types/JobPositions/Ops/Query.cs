using Connected.Entities;
using Connected.Resources.Types.JobPositions;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.JobPositions.Ops;
internal sealed class Query(IJobPositionCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<IJobPosition>>
{
	protected override async Task<IImmutableList<IJobPosition>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}
