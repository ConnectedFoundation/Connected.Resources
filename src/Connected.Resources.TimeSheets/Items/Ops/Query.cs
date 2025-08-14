using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.TimeSheets.Items.Ops;
internal sealed class Query(ITimeSheetItemCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<ITimeSheetItem>>
{
	protected override async Task<IImmutableList<ITimeSheetItem>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities<ITimeSheetItem>();
	}
}
