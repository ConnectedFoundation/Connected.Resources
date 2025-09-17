using Connected.Notifications;
using Connected.Resources.Effort.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Effort.Ops;

internal sealed class Update(IStorageProvider storage, IEventService events, IEffortCache cache, IEffortService effort)
  : ServiceAction<IUpdateEffortDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await effort.Select(Dto)) as Effort ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Effort>().Update(entity.Merge(Dto, Entities.State.Update), Dto, async () =>
		{
			await cache.Remove(Dto.Id);
			return SetState(await effort.Select(Dto)) as Effort;
		}, Caller);

		await cache.Remove(Dto.Id);
		await events.Updated(this, effort, entity.Id);
	}
}
