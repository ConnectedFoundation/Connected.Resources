using Connected.Notifications;
using Connected.Resources.Resources.WorkSheets;
using Connected.Resources.Resources.WorkSheets.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.WorkSheets.Ops;

internal sealed class Insert(IStorageProvider storage, IEventService events, IWorkSheetItemService workSheets)
	: ServiceFunction<IInsertWorkSheetItemDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<WorkSheetItem>().Update(Dto.AsEntity<WorkSheetItem>(Entities.State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		SetState(entity);

		await events.Inserted(this, workSheets, entity.Id);

		return entity.Id;
	}
}
