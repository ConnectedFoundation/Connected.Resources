using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.JobPositions.Ops;
internal sealed class Delete(IStorageProvider storage, IJobPositionService jobPositions, IEventService events, IJobPositionCache cache)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await jobPositions.Select(Dto)) as JobPosition ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<JobPosition>().Update(Dto.AsEntity<JobPosition>(State.Deleted));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, jobPositions, Dto.Id);
	}
}
