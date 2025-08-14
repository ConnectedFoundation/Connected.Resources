using Connected.Notifications;
using Connected.Resources.Effort.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Effort.Ops;

internal sealed class Insert(IStorageProvider storage, IEventService events, IEffortService effort)
  : ServiceFunction<IInsertEffortDto, long>
{
	protected override async Task<long> OnInvoke()
	{
		var entity = await storage.Open<Effort>().Update(Dto.AsEntity<Effort>(Entities.State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		SetState(entity);

		await events.Inserted(this, effort, entity.Id);

		return entity.Id;
	}
}
