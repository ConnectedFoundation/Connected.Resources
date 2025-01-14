using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.JobPositions.Ops;
internal sealed class Query(IJobPositionCache cache)
	: ServiceFunction<IQueryDto, ImmutableList<IJobPosition>>
{
	protected override async Task<ImmutableList<IJobPosition>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities<IJobPosition>();
	}
}
