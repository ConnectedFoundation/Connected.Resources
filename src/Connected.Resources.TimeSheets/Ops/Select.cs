using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.TimeSheets.Ops;
internal sealed class Select(IStorageProvider storage, ITimeSheetCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, ITimeSheet?>
{
	protected override async Task<ITimeSheet?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<TimeSheet>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}
