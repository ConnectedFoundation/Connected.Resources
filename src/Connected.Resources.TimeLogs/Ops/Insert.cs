using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.TimeLogs.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.TimeLogs.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, ITimeLogService timeLogs)
	: ServiceFunction<IInsertTimeLogDto, long>
{
	protected override async Task<long> OnInvoke()
	{
		var entity = await storage.Open<TimeLog>().Update(Dto.AsEntity<TimeLog>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await events.Inserted(this, timeLogs, entity.Id);

		return entity.Id;
	}
}
