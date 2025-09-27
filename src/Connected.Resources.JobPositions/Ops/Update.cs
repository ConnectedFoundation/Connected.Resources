using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.JobPositions.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.JobPositions.Ops;
internal sealed class Update(IStorageProvider storage, IJobPositionService jobPositions, IEventService events, IJobPositionCache cache)
	: ServiceAction<IUpdateJobPositionDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await jobPositions.Select(Dto.CreatePrimaryKey(Dto.Id))) as JobPosition ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<JobPosition>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await jobPositions.Select(Dto.CreatePrimaryKey(Dto.Id))) as JobPosition;
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, jobPositions, entity.Id);
	}
}
