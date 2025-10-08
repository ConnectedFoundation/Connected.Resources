using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Resources.TimeSheets.Items.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.TimeSheets.Items.Ops;
internal sealed class Update(IStorageProvider storage, IEventService events, ITimeSheetItemService items, ITimeSheetItemCache cache)
	: ServiceAction<IUpdateTimeSheetItemDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await items.Select(Dto)) as TimeSheetItem ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TimeSheetItem>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);
			return SetState(await items.Select(Dto)) as TimeSheetItem;
		}, Caller);

		await cache.Refresh(Dto.Id);
		await events.Updated(this, items, Dto.Id);
	}
}
