using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.TimeSheets.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.TimeSheets.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, ITimeSheetService timeSheets, ITimeSheetCache cache)
	: ServiceFunction<IInsertTimeSheetDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<TimeSheet>().Update(Dto.AsEntity<TimeSheet>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, timeSheets, entity.Id);

		return entity.Id;
	}
}