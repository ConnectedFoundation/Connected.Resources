using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.JobPositions.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.JobPositions.Ops;
internal sealed class Insert(IStorageProvider storage, IJobPositionService jobPositions, IEventService events, IJobPositionCache cache)
	: ServiceFunction<IInsertJobPositionDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<JobPosition>().Update(Dto.AsEntity<JobPosition>(State.New)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, jobPositions, entity.Id);

		return entity.Id;
	}
}
