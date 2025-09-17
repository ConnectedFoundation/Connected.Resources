using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.TimeLogs.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.TimeLogs.Ops;
internal sealed class Update(IStorageProvider storage, IEventService events, ITimeLogService timeLogs, ITimeLogCache cache)
	: ServiceAction<IUpdateTimeLogDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await timeLogs.Select(Dto)) as TimeLog ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TimeLog>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Remove(Dto.Id);

			return SetState(await timeLogs.Select(Dto)) as TimeLog;
		}, Caller);

		await events.Updated(this, timeLogs, entity.Id);
	}
}
