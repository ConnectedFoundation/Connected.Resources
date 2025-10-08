using Connected.Notifications;
using Connected.Resources.Resources.Utilization;
using Connected.Resources.Resources.Utilization.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Utilization.Ops;

internal sealed class InsertResource(IStorageProvider storage, IEventService events, IResourceUtilizationService resources)
  : ServiceFunction<IInsertResourceUtilizationDto, long>
{
	protected override async Task<long> OnInvoke()
	{
		var entity = await storage.Open<ResourceUtilization>().Update(Dto.AsEntity<ResourceUtilization>(Entities.State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		SetState(entity);

		await events.Inserted(this, resources, entity.Id);

		return entity.Id;
	}
}
