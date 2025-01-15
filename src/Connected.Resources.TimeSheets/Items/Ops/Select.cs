using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.TimeSheets.Items.Ops;
internal sealed class Select(ITimeSheetItemCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, ITimeSheetItem?>
{
	protected override async Task<ITimeSheetItem?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}
