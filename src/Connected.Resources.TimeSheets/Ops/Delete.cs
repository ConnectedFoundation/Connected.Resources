using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.TimeSheets.Ops;
internal sealed class Delete(IStorageProvider storage, ITimeSheetCache cache, IEventService events, ITimeSheetService timeSheets)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await timeSheets.Select(Dto)) as TimeSheet ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TimeSheet>().Update(Dto.AsEntity<TimeSheet>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, timeSheets, Dto.Id);
	}
}
