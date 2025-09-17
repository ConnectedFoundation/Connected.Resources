using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Effort.Ops;

internal sealed class Delete(IStorageProvider storage, IEventService events, IEffortCache cache, IEffortService effort)
  : ServiceAction<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await effort.Select(Dto)) as Effort ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Effort>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, effort, entity.Id);
	}
}
