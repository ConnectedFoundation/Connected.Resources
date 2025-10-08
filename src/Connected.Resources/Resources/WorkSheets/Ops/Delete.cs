using Connected.Notifications;
using Connected.Resources.Resources.WorkSheets;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.WorkSheets.Ops;

internal sealed class Delete(IStorageProvider storage, IEventService events, IWorkSheetItemService workSheets, IWorkSheetItemCache cache)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await workSheets.Select(Dto)) as WorkSheetItem ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<WorkSheetItem>().Update(Dto.AsEntity<WorkSheetItem>(Entities.State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, workSheets, Dto.Id);
	}
}
