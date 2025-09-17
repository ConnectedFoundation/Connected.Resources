using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.TimeSheets.Items.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.TimeSheets.Items.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, ITimeSheetItemService items, ITimeSheetItemCache cache)
	: ServiceFunction<IInsertTimeSheetItemDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = storage.Open<TimeSheetItem>().Update(Dto.AsEntity<TimeSheetItem>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, items, entity.Id);

		return entity.Id;
	}
}
