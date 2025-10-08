using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.TimeLogs.Ops;
internal sealed class Delete(IStorageProvider storage, ITimeLogCache cache, IEventService events, ITimeLogService timeLogs)
	: ServiceAction<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await timeLogs.Select(Dto)) as TimeLog ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TimeLog>().Update(Dto.AsEntity<TimeLog>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, timeLogs, Dto.Id);
	}
}
