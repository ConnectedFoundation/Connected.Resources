using Connected.Entities;
using Connected.Resources.Resources.TimeSheets.Items;
using Connected.Resources.Resources.TimeSheets.Items.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.TimeSheets.Items.Ops;
internal sealed class QueryByDate(ITimeSheetItemCache cache)
	: ServiceFunction<IQueryTimeSheetItemsDto, IImmutableList<ITimeSheetItem>>
{
	protected override async Task<IImmutableList<ITimeSheetItem>> OnInvoke()
	{
		return await cache.AsEntities(f =>
				f.TimeSheet == Dto.TimeSheet
			&& f.Start <= Dto.Date
			&& f.End >= Dto.Date);
	}
}
