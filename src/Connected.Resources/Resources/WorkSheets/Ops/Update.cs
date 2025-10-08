using Connected.Notifications;
using Connected.Resources.Resources.WorkSheets;
using Connected.Resources.Resources.WorkSheets.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.WorkSheets.Ops;

internal sealed class Update(IStorageProvider storage, IEventService events, IWorkSheetItemService workSheets, IWorkSheetItemCache cache)
	: ServiceAction<IUpdateWorkSheetItemDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await workSheets.Select(Dto)) as WorkSheetItem ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<WorkSheetItem>().Update(entity.Merge(Dto, Entities.State.Update), Dto, async () =>
		{
			await cache.Remove(Dto.Id);

			return SetState(await workSheets.Select(Dto) as WorkSheetItem ?? throw new NullReferenceException(Strings.ErrEntityExpected));
		}, Caller);

		await cache.Remove(Dto.Id);
		await events.Updated(this, workSheets, entity.Id);
	}
}
