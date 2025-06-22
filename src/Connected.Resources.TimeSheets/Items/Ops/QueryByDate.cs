using Connected.Entities;
using Connected.Resources.TimeSheets.Items.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.TimeSheets.Items.Ops;
internal sealed class QueryByDate(ITimeSheetItemCache cache)
	: ServiceFunction<IQueryTimeSheetItemsDto, ImmutableList<ITimeSheetItem>>
{
	protected override async Task<ImmutableList<ITimeSheetItem>> OnInvoke()
	{
		return await cache.AsEntities<ITimeSheetItem>(f =>
				f.TimeSheet == Dto.TimeSheet
			&& f.Start <= Dto.Date
			&& f.End >= Dto.Date);
	}
}
