using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Utilization.Ops;

internal sealed class DeleteResource(IStorageProvider storage, IEventService events, IResourceUtilizationCache cache, IResourceUtilizationService resources)
	: ServiceAction<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		SetState(await resources.Select(Dto) ?? throw new NullReferenceException(Strings.ErrEntityExpected));

		await storage.Open<ResourceUtilization>().Update(Dto.AsEntity<ResourceUtilization>(Entities.State.Deleted));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, resources, Dto.Id);
	}
}
