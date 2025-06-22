using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.WorkSheets.Ops;

internal sealed class Select(IStorageProvider storage, IWorkSheetItemCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IWorkSheetItem?>
{
	protected override async Task<IWorkSheetItem?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<WorkSheetItem>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}
