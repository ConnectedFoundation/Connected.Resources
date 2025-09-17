using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.TimeSheets.Ops;
internal sealed class Query(ITimeSheetCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<ITimeSheet>>
{
	protected override async Task<IImmutableList<ITimeSheet>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities<ITimeSheet>();
	}
}
